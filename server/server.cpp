// SingleIOCPServer.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <winsock2.h>
#include <windows.h>
#include <stdio.h>
#include <process.h>
#include <conio.h>
#include <WS2tcpip.h>
#include <iostream>
#include "ctime"
#include "string"
#include "fstream"
#include "DBConnection.h"

using namespace std;

#define PORT 5500
#define DATA_BUFSIZE 8192
#define RECEIVE 0
#define SEND 1
#define SERVER_ADDR "127.0.0.1"
#define USER_LEN 200
#define DELIMITER "\r\n"
#define BUFF_QUERY 1024

#pragma comment(lib, "Ws2_32.lib")

// Structure definition
typedef struct {
	WSAOVERLAPPED overlapped;
	WSABUF dataBuff;
	CHAR buffer[DATA_BUFSIZE];
	int bufLen;
	int recvBytes;
	int sentBytes;
	int operation;
} PER_IO_DATA, *LP_PER_IO_DATA;

typedef struct {
	SOCKET socket;
	char clientIP[INET_ADDRSTRLEN];
	int clientPort;
	char username[USER_LEN];
	bool isLogin;
	CHAR buffer[DATA_BUFSIZE];
} Session, *LP_Session;

CRITICAL_SECTION criticalSection;
ofstream logFile;
SQLHANDLE sqlConnHandle;

unsigned __stdcall serverWorkerThread(LPVOID CompletionPortID);
void communicateClient(LP_Session session);
void returnCurrentTime(string &log);
void handleProtocol(LP_Session session, string &log);
void writeInLogFile(string log);
void signUp(LP_Session session, string &log, string data);
void signIn(LP_Session session, string &log, string data);
void logOut(LP_Session session, string &log);
void sendMessage(char *buff, SOCKET &connectedSocket);
LPWSTR convertStringToLPWSTR(string param);

int main(int argc, char *argv[])
{
	SOCKADDR_IN serverAddr;
	SOCKET listenSock, acceptSock;
	HANDLE completionPort;
	SYSTEM_INFO systemInfo;
	LP_Session session;
	LP_PER_IO_DATA perIoData;
	DWORD transferredBytes;
	DWORD flags;
	WSADATA wsaData;

	if (WSAStartup((2, 2), &wsaData) != 0) {
		printf("WSAStartup() failed with error %d\n", GetLastError());
		return 1;
	}

	// Setup an I/O completion port
	if ((completionPort = CreateIoCompletionPort(INVALID_HANDLE_VALUE, NULL, 0, 0)) == NULL) {
		printf("CreateIoCompletionPort() failed with error %d\n", GetLastError());
		return 1;
	}

	// Determine how many processors are on the system
	GetSystemInfo(&systemInfo);

	// Create worker threads based on the number of processors available on the
	// system. Create two worker threads for each processor	
	for (int i = 0; i < (int)systemInfo.dwNumberOfProcessors * 2; i++) {
		// Create a server worker thread and pass the completion port to the thread
		if (_beginthreadex(0, 0, serverWorkerThread, (void*)completionPort, 0, 0) == 0) {
			printf("Create thread failed with error %d\n", GetLastError());
			return 1;
		}
	}

	// Create a listening socket
	if ((listenSock = WSASocket(AF_INET, SOCK_STREAM, 0, NULL, 0, WSA_FLAG_OVERLAPPED)) == INVALID_SOCKET) {
		printf("WSASocket() failed with error %d\n", WSAGetLastError());
		return 1;
	}

	serverAddr.sin_family = AF_INET;
	serverAddr.sin_port = htons(PORT);
	inet_pton(AF_INET, SERVER_ADDR, &serverAddr.sin_addr);
	if (bind(listenSock, (PSOCKADDR)&serverAddr, sizeof(serverAddr)) == SOCKET_ERROR) {
		printf("bind() failed with error %d\n", WSAGetLastError());
		return 1;
	}

	// Prepare socket for listening
	if (listen(listenSock, 20) == SOCKET_ERROR) {
		printf("listen() failed with error %d\n", WSAGetLastError());
		return 1;
	}

	sqlConnHandle = NULL;
	sqlConnHandle = connectDB();

	printf("Server Started!\n");
	//string query = "SELECT * FROM account WHERE username='quy' AND password='123'";
	//wchar_t wquery[BUFF_QUERY];
	//mbstowcs(wquery, query.c_str(), strlen(query.c_str()) + 1);//Plus null
	//LPWSTR ptr = wquery;

	//SQLHANDLE sqlStmtHandle = NULL;
	//
	//if (sqlStmtHandle = handleQuery(sqlConnHandle, ptr)) {
	//	SQLCHAR username[SQL_RESULT_LEN];
	//	SQLCHAR password[SQL_RESULT_LEN];
	//	SQLINTEGER ptrSqlVersion;
	//	while (SQLFetch(sqlStmtHandle) == SQL_SUCCESS) {
	//		SQLGetData(sqlStmtHandle, 2, SQL_CHAR, username, SQL_RESULT_LEN, &ptrSqlVersion);
	//		SQLGetData(sqlStmtHandle, 3, SQL_CHAR, password, SQL_RESULT_LEN, &ptrSqlVersion);
	//		// display query result
	//		cout << "\nQuery Result:\n\n";
	//		cout << username << " " << password << endl;
	//		string str1((const char*)username);
	//		string str2((const char*)password);
	//		cout << str1.length() << " " << str2.length() << endl;
	//	}
	//}
	
	InitializeCriticalSection(&criticalSection);
	while (1) {
		sockaddr_in clientAddr;
		int clientLength = sizeof(clientAddr);

		// Step 5: Accept connections
		if ((acceptSock = WSAAccept(listenSock, (sockaddr *)&clientAddr, &clientLength, NULL, 0)) == SOCKET_ERROR) {
			printf("WSAAccept() failed with error %d\n", WSAGetLastError());
			return 1;
		}

		// Step 6: Create a socket information structure to associate with the socket
		if ((session = (LP_Session)GlobalAlloc(GPTR, sizeof(Session))) == NULL) {
			printf("GlobalAlloc() failed with error %d\n", GetLastError());
			return 1;
		}

		// Step 7: Associate the accepted socket with the original completion port
		printf("Socket number %d got connected...\n", acceptSock);
		session->socket = acceptSock;
		if (CreateIoCompletionPort((HANDLE)acceptSock, completionPort, (DWORD)session, 0) == NULL) {
			printf("CreateIoCompletionPort() failed with error %d\n", GetLastError());
			return 1;
		}

		// Step 8: Create per I/O socket information structure to associate with the WSARecv call
		if ((perIoData = (LP_PER_IO_DATA)GlobalAlloc(GPTR, sizeof(perIoData))) == NULL) {
			printf("GlobalAlloc() failed with error %d\n", GetLastError());
			return 1;
		}

		ZeroMemory(&(perIoData->overlapped), sizeof(OVERLAPPED));
		perIoData->sentBytes = 0;
		perIoData->recvBytes = 0;
		perIoData->dataBuff.len = DATA_BUFSIZE;
		perIoData->dataBuff.buf = perIoData->buffer;
		perIoData->operation = RECEIVE;
		flags = 0;
		inet_ntop(AF_INET, &clientAddr.sin_addr, session->clientIP, sizeof(session->clientIP));
		session->clientPort = ntohs(clientAddr.sin_port);
		session->isLogin = false;

		if (WSARecv(acceptSock, &(perIoData->dataBuff), 1, &transferredBytes, &flags, &(perIoData->overlapped), NULL) == SOCKET_ERROR) {
			if (WSAGetLastError() != ERROR_IO_PENDING) {
				printf("WSARecv() failed with error %d\n", WSAGetLastError());
				return 1;
			}
		}
	}
	DeleteCriticalSection(&criticalSection);
	_getch();
	return 0;
}

unsigned __stdcall serverWorkerThread(LPVOID completionPortID)
{
	HANDLE completionPort = (HANDLE)completionPortID;
	DWORD transferredBytes;
	LP_Session session;
	LP_PER_IO_DATA perIoData;
	DWORD flags;

	char queue[DATA_BUFSIZE];

	while (TRUE) {
		if (GetQueuedCompletionStatus(completionPort, &transferredBytes,
			(LPDWORD)&session, (LPOVERLAPPED *)&perIoData, INFINITE) == 0) {
			printf("GetQueuedCompletionStatus() failed with error %d\n", GetLastError());
			return 0;
		}
		// Check to see if an error has occurred on the socket and if so
		// then close the socket and cleanup the SOCKET_INFORMATION structure
		// associated with the socket
		if (transferredBytes == 0) {
			printf("Closing socket %d\n", session->socket);
			if (closesocket(session->socket) == SOCKET_ERROR) {
				printf("closesocket() failed with error %d\n", WSAGetLastError());
				return 0;
			}
			GlobalFree(session);
			GlobalFree(perIoData);
			continue;
		}
		// Check to see if the operation field equals RECEIVE. If this is so, then
		// this means a WSARecv call just completed so update the recvBytes field
		// with the transferredBytes value from the completed WSARecv() call
		if (perIoData->operation == RECEIVE) {
			char rs[DATA_BUFSIZE];
			ZeroMemory(&rs, sizeof(DATA_BUFSIZE));
			perIoData->buffer[transferredBytes] = 0;
			strcpy(queue, perIoData->buffer);
			// Handle byte stream
			while (strstr(queue, DELIMITER) != NULL)
			{
				string strQueue = string(queue);
				string data = strQueue.substr(0, strQueue.find(DELIMITER));
				strcpy(session->buffer, data.c_str());
				communicateClient(session);
				strcpy(queue, strstr(queue, DELIMITER) + strlen(DELIMITER));
				if (strlen(queue) != 0) {
					perIoData->dataBuff.buf = session->buffer;
					perIoData->dataBuff.len = strlen(session->buffer);
					if (WSARecv(session->socket,
						&(perIoData->dataBuff),
						1,
						&transferredBytes,
						&flags,
						&(perIoData->overlapped), NULL) == SOCKET_ERROR) {
						if (WSAGetLastError() != ERROR_IO_PENDING) {
							printf("WSARecv() failed with error %d\n", WSAGetLastError());
							return 0;
						}
					}
				}
				else {
					strcat(rs, session->buffer);
				}
			}
			strcpy(perIoData->buffer, rs);
			perIoData->recvBytes = strlen(perIoData->buffer);
			perIoData->sentBytes = 0;
			perIoData->operation = SEND;
		}
		else if (perIoData->operation == SEND) {
			perIoData->sentBytes += transferredBytes;
		}

		if (perIoData->recvBytes > perIoData->sentBytes) {
			// Post another WSASend() request.
			// Since WSASend() is not guaranteed to send all of the bytes requested,
			// continue posting WSASend() calls until all received bytes are sent.
			ZeroMemory(&(perIoData->overlapped), sizeof(OVERLAPPED));
			perIoData->dataBuff.buf = perIoData->buffer + perIoData->sentBytes;
			perIoData->dataBuff.len = perIoData->recvBytes - perIoData->sentBytes;
			perIoData->operation = SEND;
			if (WSASend(session->socket,
				&(perIoData->dataBuff),
				1,
				&transferredBytes,
				0,
				&(perIoData->overlapped),
				NULL) == SOCKET_ERROR) {
				if (WSAGetLastError() != ERROR_IO_PENDING) {
					printf("WSASend() failed with error %d\n", WSAGetLastError());
					return 0;
				}
			}
		}
		else {
			// No more bytes to send post another WSARecv() request
			perIoData->recvBytes = 0;
			perIoData->operation = RECEIVE;
			flags = 0;
			ZeroMemory(&(perIoData->overlapped), sizeof(OVERLAPPED));
			perIoData->dataBuff.len = DATA_BUFSIZE;
			perIoData->dataBuff.buf = perIoData->buffer;
			ZeroMemory(&(perIoData->buffer), sizeof(DATA_BUFSIZE));
			if (WSARecv(session->socket,
				&(perIoData->dataBuff),
				1,
				&transferredBytes,
				&flags,
				&(perIoData->overlapped), NULL) == SOCKET_ERROR) {
				if (WSAGetLastError() != ERROR_IO_PENDING) {
					printf("WSARecv() failed with error %d\n", WSAGetLastError());
					return 0;
				}
			}
		}
	}
}

// Communicate with client
// @param client - Pointer input data and info client
void communicateClient(LP_Session session) {
	string log;
	// write clientIp and clientPort to log variable 
	log = session->clientIP;
	log += ":" + to_string(session->clientPort);
	// write current time to log variable 
	returnCurrentTime(log);
	// handle message
	handleProtocol(session, log);
}

// Return current time when user send message to server
void returnCurrentTime(string &log) {
	log += "[";
	time_t current = time(0); // current time
	tm *ltm = localtime(&current);
	log += to_string(ltm->tm_mday) + "/"; // day
	log += to_string(ltm->tm_mon + 1) + "/"; // month
	log += to_string(ltm->tm_year + 1900) + " "; // year
	log += to_string(ltm->tm_hour) + ":"; // hour
	log += to_string(ltm->tm_min) + ":"; // minutes
	log += to_string(ltm->tm_sec) + "]" + " $ "; // seconds
}

LPWSTR convertStringToLPWSTR(string param) {
	wchar_t wquery[BUFF_QUERY];
	mbstowcs(wquery, param.c_str(), strlen(param.c_str()) + 1);//Plus null
	LPWSTR lquery = wquery;
	return lquery;
}

// Split protocol and message from client, handle protocol
// @param client - Pointer input data and info client
// @param log - reference variable store the activity log 
void handleProtocol(LP_Session session, string &log) {

	string str(session->buffer);
	// Write message to log variable
	log += str + " $ ";
	string key = str.substr(0, 6);
	string data;
	if (str.length() > 6) {
		data = str.substr(7);
	}
	if (key == "SIGNUP") {
		if (session->isLogin) {
			// check login
			log += "401";
			strcpy(session->buffer, "401 you are logged in, Please log out first!");
			/*writeInLogFile(log);*/
		}
		else {
			signUp(session, log, data);
		}
	}
	else if (key == "SIGNIN") {
		if (session->isLogin) {
			// check login
			log += "401";
			strcpy(session->buffer, "401 you are logged in, Please log out first!");
			writeInLogFile(log);
		}
		else {
			signIn(session, log, data);
		}
	}
	else if (key == "LOGOUT") {
		if (!session->isLogin) {
			// check login
			log += "402";
			strcpy(session->buffer, "402 You are not log in");
			writeInLogFile(log);
		}
		else {
			logOut(session, log);
		}
	}
	else {
		log += "403";
		strcpy(session->buffer, "403 Wrong protocol!");
		// Write in log file
		writeInLogFile(log);
	}
}

void writeInLogFile(string log) {
	EnterCriticalSection(&criticalSection);
	logFile.open("log_20183816.txt", ios::out | ios::app);
	if (logFile.is_open()) {
		logFile << log + "\n";
		logFile.close();
	}
	else cout << "Unable to open file.";
	LeaveCriticalSection(&criticalSection);
}

void signUp(LP_Session session, string &log, string data) {
	char rs[DATA_BUFSIZE];
	memset(rs, 0, DATA_BUFSIZE);
	SQLHANDLE sqlStmtHandle;
	sqlStmtHandle = NULL;
	string strUsername = data.substr(0, data.find("\n"));
	string strPassword = data.substr(data.find("\n") + 1);
	string query = "SELECT * FROM account WHERE username='" + strUsername + "'";
	// convert string to L string
	PWSTR lquery = convertStringToLPWSTR(query);
	// handle query
	EnterCriticalSection(&criticalSection);
	sqlStmtHandle = handleQuery(sqlConnHandle, lquery);
	LeaveCriticalSection(&criticalSection);
	int fetch = SQLFetch(sqlStmtHandle);
	if (sqlStmtHandle) {
		if (fetch == SQL_SUCCESS) {
			strcat_s(rs, "400 Account already exists!");
			log += "400";
			strcpy(session->buffer, rs);
		}
		else {
			query = "INSERT INTO account VALUES ('" + strUsername + "','" + strPassword + "')";
			// convert string to L string
			lquery = convertStringToLPWSTR(query);
			// handle query	
			EnterCriticalSection(&criticalSection);
			sqlStmtHandle = handleQuery(sqlConnHandle, lquery);
			LeaveCriticalSection(&criticalSection);
			strcat_s(rs, "200 Sign up success!");
			log += "200";
			strcpy(session->buffer, rs);
		}
	}
	SQLFreeHandle(SQL_HANDLE_STMT, sqlStmtHandle);
	writeInLogFile(log);
}

// Login function handle login request from client
// @param client - Pointer input data and info client
// @param log - reference variable store the activity log 
// @param data - message without protocol send by client
void signIn(LP_Session session, string &log, string data) {
	char rs[DATA_BUFSIZE];
	memset(rs, 0, DATA_BUFSIZE);
	SQLHANDLE sqlStmtHandle;
	sqlStmtHandle = NULL;
	string strUsername = data.substr(0, data.find("\n"));
	string strPassword = data.substr(data.find("\n")+1);
	string query = "SELECT * FROM account WHERE username='" + strUsername + "' AND password='" + strPassword + "'";
	// convert string to L string
	PWSTR lquery = convertStringToLPWSTR(query);
	// handle query
	EnterCriticalSection(&criticalSection);
	sqlStmtHandle = handleQuery(sqlConnHandle, lquery);
	LeaveCriticalSection(&criticalSection);
	int fetch = SQLFetch(sqlStmtHandle);
	if (sqlStmtHandle) {
		if (fetch == SQL_SUCCESS) {
			strcat_s(rs, "210 Sign in success!");
			log += "210";
			strcpy(session->buffer, rs);
			session->isLogin = true;
			strcpy(session->username, strUsername.c_str());
		}
		else {
			strcat_s(rs, "410 Incorrect account and password !");
			log += "410";
			strcpy(session->buffer, rs);
		}
	}
	SQLFreeHandle(SQL_HANDLE_STMT, sqlStmtHandle);
	writeInLogFile(log);
}

// Handle Log Out Request
// @param client - Pointer input data and info client
// @param log - reference variable store the activity log 
void logOut(LP_Session session, string &log) {
	char rs[DATA_BUFSIZE];
	memset(rs, 0, DATA_BUFSIZE);
	// Handle critical resource

	strcat_s(rs, "220 Logout sucessfull!");
	log += "220";
	session->isLogin = false;
	memset(session->username, 0, USER_LEN);

	strcpy(session->buffer, rs);
	// Write in log file
	writeInLogFile(log);
}

// Send message
void sendMessage(char *buff, SOCKET &connectedSocket) {

	int ret = send(connectedSocket, buff, strlen(buff), 0);
	if (ret == SOCKET_ERROR) {
		printf("Error %d: Can't send data.\n", WSAGetLastError());
	}
}