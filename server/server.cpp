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
#define MAX_PLAYER_IN_ROOM 4
#define MAX_ROOM 256
#define QUIZ_SIZE 10

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
	int userID;
	string answer;
	char username[USER_LEN];
	int score;
	string roomID;
	int position; //position in Room
	int roomLoc; // position of room in array
}Player, *LP_Player;

typedef struct {
	char question[BUFF_QUERY];
	char correct_answer[BUFF_QUERY];
}Question, *LP_Question;


typedef struct {
	SOCKET socket;
	char clientIP[INET_ADDRSTRLEN];
	int clientPort;
	char username[USER_LEN];
	bool isLogin;
	CHAR buffer[DATA_BUFSIZE];
	string sessionID;
	int userID;
	LP_Player player;
} Session, *LP_Session;

typedef struct {
	string roomID;
	LP_Player roomMaster;
	int numberOfPlayer;
	int numberAnswer;
	int questionNumber;
	int numberGetQuestion;
	LP_Player players[MAX_PLAYER_IN_ROOM];
	boolean is_started;
	LP_Question quizzes[QUIZ_SIZE];
} Room, *LP_Room;

CRITICAL_SECTION criticalSection;
ofstream logFile;
SQLHANDLE sqlConnHandle;
LP_Room rooms[MAX_ROOM];
int numberOfRooms = 0;

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
void createRoom(LP_Session, string &log);
string gen_random(const int len);
void gointoRoom(LP_Session session, string &log, string roomID);
void startGame(LP_Session session, string &log);
void getQuiz(LP_Session session, string &log);
void exitRoom(LP_Session session, string &log);
void updateLoginStatus(string username, string isLogin);
void handleAnswer(LP_Session session, string &log, string data);
void getResult(LP_Session session, string &log);
void getQuizDB(LP_Question *quiz);

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

	// allocate room
	for (int i = 0; i < MAX_ROOM; ++i) {
		if ((rooms[i] = (LP_Room)GlobalAlloc(GPTR, sizeof(Room))) == NULL) {
			printf("GlobalAlloc() failed with error %d\n", GetLastError());
			return 1;
		}
		/*if ((rooms[i]->roomMaster = (LP_Player)GlobalAlloc(GPTR, sizeof(Player))) == NULL) {
			printf("GlobalAlloc() failed with error %d\n", GetLastError());
			return 1;
		}*/
		rooms[i]->roomMaster = 0;
		rooms[i]->numberOfPlayer = 0;
		for (int j = 0; j < MAX_PLAYER_IN_ROOM; ++j) {
			/*if ((rooms[i]->players[j] = (LP_Player)GlobalAlloc(GPTR, sizeof(Player))) == NULL) {
				printf("GlobalAlloc() failed with error %d\n", GetLastError());
				return 1;
			}*/
			rooms[i]->players[j] = 0;
		}
		for (int j = 0; j < QUIZ_SIZE; ++j) {
			rooms[i]->quizzes[j] = 0;
		}
	}

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
		if ((session->player = (LP_Player)GlobalAlloc(GPTR, sizeof(Player))) == NULL) {
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
		if ((perIoData = (LP_PER_IO_DATA)GlobalAlloc(GPTR, sizeof(PER_IO_DATA))) == NULL) {
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
		session->sessionID = gen_random(6);

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

			//if player in room, notice to other player in room know this player leave
			LP_Player player = session->player;
			if (player->roomID.length() > 0) {
				string log;
				// write clientIp and clientPort to log variable 
				log = session->clientIP;
				log += ":" + to_string(session->clientPort);
				// write current time to log variable 
				returnCurrentTime(log);
				log += "EXITRM $ ";
				exitRoom(session, log);
			}
			//update login status to database
			string username(session->username);
			updateLoginStatus(username, "0");
			return 0;
		}
		// Check to see if an error has occurred on the socket and if so
		// then close the socket and cleanup the SOCKET_INFORMATION structure
		// associated with the socket
		if (transferredBytes == 0) {
			//if player in room, notice to other player in room know this player leave
			LP_Player player = session->player;
			if (player->roomID.length() > 0) {
				string log;
				// write clientIp and clientPort to log variable 
				log = session->clientIP;
				log += ":" + to_string(session->clientPort);
				// write current time to log variable 
				returnCurrentTime(log);
				log += "EXITRM $ ";
				exitRoom(session, log);
			}
			//update login status to database
			string username(session->username);
			updateLoginStatus(username, "0");

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
			cout << "result ..: " << queue << endl;
			// Handle byte stream
			while (strstr(queue, DELIMITER) != NULL)
			{
				string strQueue = string(queue);
				string data = strQueue.substr(0, strQueue.find(DELIMITER));
				strcpy(session->buffer, data.c_str());
				// Handle message in client
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

// Split protocol and message from client, handle protocol
// @param client - Pointer input data and info client
// @param log - reference variable store the activity log 
void handleProtocol(LP_Session session, string &log) {
	string str(session->buffer);
	// Write message to log variable
	log += str + " $ ";
	string key = str.substr(0, 6);
	string data = "";
	if (str.length() > 6) {
		data = str.substr(7);
	}
	cout << key << endl;
	if (key == "SIGNUP") {
		if (session->isLogin) {
			// check login
			log += "401";
			strcpy(session->buffer, "401 you are logged in, Please log out first!");
			writeInLogFile(log);
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
	else if (key == "CREATE") {
		if (!session->isLogin) {
			// check login
			log += "402";
			strcpy(session->buffer, "402 You are not log in");
			writeInLogFile(log);
		}
		else {
			createRoom(session, log);
		}
	}
	else if (key == "GOINTO") {
		if (!session->isLogin) {
			// check login
			log += "402";
			strcpy(session->buffer, "402 You are not log in");
			writeInLogFile(log);
		}
		else {
			gointoRoom(session, log, data);
		}
	}
	else if (key == "EXITRM") {
		if (!session->isLogin) {
			// check login
			log += "402";
			strcpy(session->buffer, "402 You are not log in");
			writeInLogFile(log);
		}
		else {
			exitRoom(session, log);
		}
	}
	else if (key == "STARTT") {
		if (!session->isLogin) {
			// check login
			log += "402";
			strcpy(session->buffer, "402 You are not log in");
			writeInLogFile(log);
		}
		else {
			startGame(session, log);
		}
	}
	else if (key == "QUIZZZ") {
		if (!session->isLogin) {
			// check login
			log += "402";
			strcpy(session->buffer, "402 you are not log in");
			writeInLogFile(log);
		}
		else {
			getQuiz(session, log);
		}
	}
	else if (key == "ANSWER") {
		if (!session->isLogin) {
			// check login
			log += "402";
			strcpy(session->buffer, "402 you are not log in");
			writeInLogFile(log);
		}
		else {
			handleAnswer(session, log, data);
		}
	}
	else if (key == "RESULT") {
		if (!session->isLogin) {
			// check login
			log += "402";
			strcpy(session->buffer, "402 you are not log in");
			writeInLogFile(log);
		}
		else {
			getResult(session, log);
		}
	}
	else {
		log += "500";
		strcpy(session->buffer, "500 Wrong protocol!");
		// Write in log file
		writeInLogFile(log);
	}
}

void getResult(LP_Session session, string &log) {

}

// handle answer
void handleAnswer(LP_Session session, string &log, string data) {
	LP_Player player = session->player;
	session->player->answer = data;
	char buff[DATA_BUFSIZE];
	memset(buff, 0, DATA_BUFSIZE);
	string rs;
	int bestAnswer = INT_MAX;
	int playerAnswerCorrect, correctAnswer, roomIndex;
	EnterCriticalSection(&criticalSection);
	roomIndex = session->player->roomLoc;
	rooms[roomIndex]->numberAnswer++;
	if (rooms[roomIndex]->numberAnswer == rooms[roomIndex]->numberOfPlayer) {
		strcat(buff, "260 ");
		correctAnswer = atoi(rooms[roomIndex]->quizzes[rooms[roomIndex]->questionNumber]->correct_answer);
		cout << "numberAnswer: " << rooms[roomIndex]->numberAnswer << endl;
		for (int i = 0; i < MAX_PLAYER_IN_ROOM; ++i) {
			cout << rooms[roomIndex]->players[i] << endl;
			if (rooms[roomIndex]->players[i]) {
				if (rooms[roomIndex]->players[i]->answer != "") {
					int distance = stoi(rooms[roomIndex]->players[i]->answer) - correctAnswer;
					if (distance < bestAnswer) {
						bestAnswer = distance;
						playerAnswerCorrect = i;
					}
				}
			}
		}
		rooms[roomIndex]->players[playerAnswerCorrect]->score += 10;
		
		for (int i = 0; i < MAX_PLAYER_IN_ROOM; ++i) {
			if (rooms[roomIndex]->players[i]) {
				rs = rooms[roomIndex]->players[i]->username;
				rs += " " + rooms[roomIndex]->players[i]->answer + " " + to_string(rooms[roomIndex]->players[i]->score) + "\n";
				strcat(buff, rs.c_str());
			}
			else {
				strcat(buff, "\n");
			}
		}
		cout << "check1" << endl;
		for (int i = 0; i < MAX_PLAYER_IN_ROOM; ++i) {
			cout << "check2" << endl;
			cout << rooms[roomIndex]->players[i] << endl;
			if (rooms[roomIndex]->players[i]) {
				if (rooms[roomIndex]->players[i]->userID != session->player->userID) {
					cout << "in"<< buff << endl;
					sendMessage(buff, rooms[roomIndex]->players[i]->socket);
				}
			}
		}
		rooms[roomIndex]->numberAnswer = 0;
	}
	/*else {
		strcat(buff, "260 ");
		for (int i = 0; i < MAX_PLAYER_IN_ROOM; ++i) {
			if (rooms[roomIndex]->players[i]) {
				if (rooms[roomIndex]->players[i]->userID == session->player->userID) {
					rs = rooms[roomIndex]->players[i]->username;
					rs += " " + rooms[roomIndex]->players[i]->answer + " " + to_string(rooms[roomIndex]->players[i]->score) + "\n";
					strcat(buff, rs.c_str());
				}
				else {
					strcat(buff, "\n");
				}
			}
			else {
				strcat(buff, "\n");
			}
		}
	}*/
	cout << buff << endl;
	LeaveCriticalSection(&criticalSection);
	strcpy(session->buffer, buff);
	writeInLogFile(log);
}

// start game
void startGame(LP_Session session, string &log) {
	LP_Player player = session->player;
	LP_Question *quizzes;
	int roomIndex;
	EnterCriticalSection(&criticalSection);
	roomIndex = player->roomLoc;
	bool checkMaster = rooms[roomIndex]->roomMaster->userID != player->userID;
	rooms[roomIndex]->numberAnswer = 0;
	for (int i = 0; i < MAX_PLAYER_IN_ROOM; ++i) {
		if (rooms[roomIndex]->players[i])
			rooms[roomIndex]->players[i]->score = 0;
	}
	rooms[roomIndex]->questionNumber = 0;
	rooms[roomIndex]->numberGetQuestion = 0;
	quizzes = rooms[session->player->roomLoc]->quizzes;
	LeaveCriticalSection(&criticalSection);
	if (checkMaster) {
		// if player is not room master
		log += "451";
		strcpy(session->buffer, "451 player is not room master");
	}
	else {
		log += "250";
		strcpy(session->buffer, "250 start game");
		char buff[DATA_BUFSIZE];
		strcpy(buff, "250 start game");
		getQuizDB(quizzes);
		EnterCriticalSection(&criticalSection);
		rooms[roomIndex]->numberAnswer = 0;
		for (int i = 0; i < MAX_PLAYER_IN_ROOM; ++i) {
			if (rooms[roomIndex]->players[i]) {
				cout << "test rooms " << rooms[roomIndex]->players[i]->userID << endl;
				if (rooms[roomIndex]->players[i]->userID != rooms[roomIndex]->roomMaster->userID) {
					sendMessage(buff, rooms[roomIndex]->players[i]->socket);
				}
			}
		}
		LeaveCriticalSection(&criticalSection);
	}
	cout << session->buffer << endl;
	writeInLogFile(log);
}

void getQuiz(LP_Session session, string &log) {
	LP_Player player = session->player;
	string rs;
	int roomIndex;
	string question;
	EnterCriticalSection(&criticalSection);
	roomIndex = player->roomLoc;
	question = rooms[roomIndex]->quizzes[rooms[roomIndex]->questionNumber]->question;
	rooms[roomIndex]->numberGetQuestion++;
	if (rooms[roomIndex]->numberGetQuestion == rooms[roomIndex]->numberOfPlayer) {
		rooms[roomIndex]->numberGetQuestion = 0;
		rooms[roomIndex]->questionNumber++;
	}
	cout << rooms[roomIndex]->numberGetQuestion << endl;
	cout << rooms[roomIndex]->questionNumber << endl;
	LeaveCriticalSection(&criticalSection);
	rs = "290 " + question;
	strcpy(session->buffer, rs.c_str());
	writeInLogFile(log);
}

// get quiz
void getQuizDB(LP_Question *quiz) {
	SQLHANDLE sqlStmtHandle;
	sqlStmtHandle = NULL;
	string query = "SELECT TOP 10 * FROM quiz";
	// convert string to L string
	PWSTR lquery = convertStringToLPWSTR(query);
	// handle query
	EnterCriticalSection(&criticalSection);
	sqlStmtHandle = handleQuery(sqlConnHandle, lquery);
	LeaveCriticalSection(&criticalSection);

	for (int i = 0; i < QUIZ_SIZE; ++i) {
		int fetch = SQLFetch(sqlStmtHandle);
		if (sqlStmtHandle) {
			if (fetch == SQL_SUCCESS) {
				if ((quiz[i] = (LP_Question)GlobalAlloc(GPTR, sizeof(Question))) == NULL) {
					printf("GlobalAlloc() failed with error %d\n", GetLastError());
				}
				else {
					SQLINTEGER ptrSqlVersion;
					SQLGetData(sqlStmtHandle, 2, SQL_C_CHAR, &quiz[i]->question, SQL_RESULT_LEN, &ptrSqlVersion);
					SQLGetData(sqlStmtHandle, 3, SQL_C_CHAR, &quiz[i]->correct_answer, SQL_RESULT_LEN, &ptrSqlVersion);
					cout << quiz[i]->question << endl;
					cout << quiz[i]->correct_answer << endl;
				}
			}
		}
	}
	/*if (sqlStmtHandle) {
		while (SQLFetch(sqlStmtHandle) == SQL_SUCCESS) {
			SQLINTEGER ptrSqlVersion;
			SQLGetData(sqlStmtHandle, 2, SQL_C_CHAR, &quiz->question, SQL_RESULT_LEN, &ptrSqlVersion);
			SQLGetData(sqlStmtHandle, 3, SQL_C_CHAR, &quiz->correct_answer, SQL_RESULT_LEN, &ptrSqlVersion);
			log += "290";
			rs = quiz->question;
			rs = "290 " + rs;
			cout << quiz->question << endl;
			cout << quiz->correct_answer << endl;

			char buff[DATA_BUFSIZE];
			strcpy(buff, rs.c_str());

			EnterCriticalSection(&criticalSection);
			rooms[roomIndex]->numberAnswer = 0;
			cout << "check outside" << endl;
			cout << "room Master " << rooms[roomIndex]->roomMaster << " " << rooms[roomIndex]->roomMaster->userID << endl;
			for (int i = 0; i < MAX_PLAYER_IN_ROOM; ++i) {
				cout << rooms[roomIndex]->players[i] << endl;
				if (rooms[roomIndex]->players[i]) {
					cout << "test rooms " << rooms[roomIndex]->players[i]->userID << endl;
					if (rooms[roomIndex]->players[i]->userID != session->player->userID) {
						cout << "check" << endl;
						sendMessage(buff, rooms[roomIndex]->players[i]->socket);
					}
				}
			}
			LeaveCriticalSection(&criticalSection);
		}
	}*/
	SQLFreeHandle(SQL_HANDLE_STMT, sqlStmtHandle);
}

/* The exitRoom function create a room
* @param session - LP_Session struct pointer manage user
* @param log - reference variable store the activity log
* @return No return value
*/
void createRoom(LP_Session session, string &log) {
	LP_Player player = session->player;
	int i;
	EnterCriticalSection(&criticalSection);
	for (i = 0; i < MAX_ROOM; ++i) {
		if (rooms[i]->numberOfPlayer == 0) {
			break;
		}
	}
	LeaveCriticalSection(&criticalSection);
	if (i != MAX_ROOM) {
		player->roomLoc = i;
		player->socket = session->socket;
		numberOfRooms++;
		rooms[i]->roomMaster = player;
		rooms[i]->players[0] = player;
		rooms[i]->numberOfPlayer++;
		rooms[i]->roomID = gen_random(6);
		rooms[i]->is_started = false;
		player->roomID = rooms[i]->roomID;
		player->position = 0;
		string buff = "230 " + rooms[i]->roomID + "\n" + to_string(rooms[i]->numberOfPlayer) + "\n" + player->username;

		strcpy(session->buffer, buff.c_str());
		log += "230";
	}
	else {
		strcpy(session->buffer, "430 Full Room!");
		log += "430";
	}
	writeInLogFile(log);
}

/* The gointoRoom function handle go into room request
* @param session - LP_Session struct pointer manage user
* @param log - reference variable store the activity log
* @param roomID - ID room if player go into room by roomID
* @return No return value
*/
void gointoRoom(LP_Session session, string &log, string roomID) {
	EnterCriticalSection(&criticalSection);
	LP_Player player = session->player;
	if (roomID.length() == 0) {
#pragma region Go into room at random
		//go into the room at random
		if (numberOfRooms == 0) {
			LeaveCriticalSection(&criticalSection);
			createRoom(session, log);
		}
		else {
			for (int j = 0; j < numberOfRooms; ++j) { 
				//find out the first room which has at least 1 player to join 
				//1. The room isn't full and didn't start
				if (rooms[j]->numberOfPlayer < MAX_PLAYER_IN_ROOM && rooms[j]->is_started == false) {
					//Join room successfully
					string playersInRoom = "";
					for (int i = 0; i < MAX_PLAYER_IN_ROOM; ++i) {
						if (rooms[j]->players[i] == NULL) {
							rooms[j]->players[i] = player;
							player->position = i;
							break;
						}
						playersInRoom = playersInRoom + rooms[j]->players[i]->username + "*";
					}
					playersInRoom += player->username;
					player->roomID = rooms[j]->roomID;
					player->roomLoc = j;
					player->socket = session->socket;
					rooms[j]->numberOfPlayer++;

					string sendData = "240 " + rooms[j]->roomID + "\n" + playersInRoom;
					strcpy(session->buffer, sendData.c_str());

					string dataForOtherPlayers = "241 " + playersInRoom;

					//send to another players in room
					for (int i = 0; i < MAX_PLAYER_IN_ROOM; ++i) {
						if (rooms[j]->players[i]) {
							if (rooms[j]->players[i]->userID != rooms[j]->players[player->position]->userID) {
								char buff[DATA_BUFSIZE];
								strcpy(buff, dataForOtherPlayers.c_str());
								sendMessage(buff, rooms[j]->players[i]->socket);
							}
						}
					}
					log += "240";
					writeInLogFile(log);
					LeaveCriticalSection(&criticalSection);
					return;
				}
			}
			//if don't have any satified rooms in numberOfRooms
			if (numberOfRooms < MAX_ROOM) {
				LeaveCriticalSection(&criticalSection);
				createRoom(session, log);
			}
			else {
				//full room
				strcpy(session->buffer, "443 Don't have available rooms.");
				log += "443";
				writeInLogFile(log);
				LeaveCriticalSection(&criticalSection);
			}
		}
#pragma endregion
	}
	else {

#pragma region Go room By Id
		for (int i = 0; i < MAX_ROOM; ++i) {
			cout << "room i : " << rooms[i]->roomID << endl;
			if (rooms[i]->roomID.length() == 0) {
				strcpy(session->buffer, "440 Room doesn't exist.");
				log += "440";
				writeInLogFile(log);
				LeaveCriticalSection(&criticalSection);
				return;
			}
			if (rooms[i]->roomID == roomID) {

				if (rooms[i]->numberOfPlayer == MAX_PLAYER_IN_ROOM) {
					strcpy(session->buffer, "441 Full players in room.");
					log += "441";
					writeInLogFile(log);
					LeaveCriticalSection(&criticalSection);
					return;
				}
				if (rooms[i]->is_started) {
					strcpy(session->buffer, "442 Game is being played.");
					log += "442";
					writeInLogFile(log);
					LeaveCriticalSection(&criticalSection);
					return;
				}
				//Join room succesfful
				for (int j = 0; j < MAX_PLAYER_IN_ROOM; ++j) {
					cout << "roomID length " << rooms[i]->players[j] << endl;
					if (!rooms[i]->players[j]) {
						rooms[i]->players[j] = player;
						player->position = j;
						break;
					}
				}
				player->roomID = rooms[i]->roomID;

				player->socket = session->socket;
				player->roomLoc = i;

				rooms[i]->numberOfPlayer++;
				string playersInRoom = "";
				for (int j = 0; j < MAX_PLAYER_IN_ROOM; ++j) {
					if (rooms[i]->players[j]) {
						playersInRoom = playersInRoom + rooms[i]->players[j]->username + "*";
					}
				}
				string players = playersInRoom.substr(0, playersInRoom.size() - 1);
				string sendData = "240 " + rooms[i]->roomID + "\n" + players;
				strcpy(session->buffer, sendData.c_str());

				string dataForOtherPlayers = "241 " + players;

				//send to another players in room
				for (int j = 0; j < MAX_PLAYER_IN_ROOM; ++j) {
					cout << rooms[i]->players[j] << endl;
					if (rooms[i]->players[j]) {
						if (rooms[i]->players[j]->userID != rooms[i]->players[player->position]->userID) {
							char buff[DATA_BUFSIZE];
							strcpy(buff, dataForOtherPlayers.c_str());
							sendMessage(buff, rooms[i]->players[j]->socket);
						}
					}
				}
				log += "240";
				writeInLogFile(log);
				LeaveCriticalSection(&criticalSection);
				return;
			}
		}
		strcpy(session->buffer, "440 Room doesn't exist.");
		log += "440";
		writeInLogFile(log);
		LeaveCriticalSection(&criticalSection);
#pragma endregion
	}

}

/* The exitRoom function handle exit room request
* @param session - LP_Session struct pointer manage user
* @param log - reference variable store the activity log
* @return No return value
*/
void exitRoom(LP_Session session, string &log) {
	EnterCriticalSection(&criticalSection);
	LP_Player player = session->player;
	if (player->roomID.length() == 0) {
		strcpy(session->buffer, "481 You isn't in any rooms.");
		log += "481";
		writeInLogFile(log);
		LeaveCriticalSection(&criticalSection);
	}
	else {
		//Being in a room
		LP_Room room = rooms[player->roomLoc];
		
		//If have another players in room
		if (room->numberOfPlayer > 1) {
			//If player is roomMaster, set new room Master
			if (player->userID == room->roomMaster->userID) {
				for (int i = 0; i < MAX_PLAYER_IN_ROOM; ++i) {
					if (room->players[i]) {
						if (room->players[i]->userID != player->userID) {
							room->roomMaster = room->players[i];
							break;
						}
					}
				}
			}
			//Notice to another players in room
			string dataForOtherPlayers; 
			for (int i = 0; i < MAX_PLAYER_IN_ROOM; ++i) {
				if (room->players[i]) {
					if (room->players[i]->userID != room->players[player->position]->userID) {
						if (room->players[i]->userID == room->roomMaster->userID) { //if that player is new room Master
							dataForOtherPlayers = "281 " + to_string(player->position) + "\n" + "1";
						}
						else {
							dataForOtherPlayers = "281 " + to_string(player->position) + "\n" + "0";
						}
						char buff[DATA_BUFSIZE];
						strcpy(buff, dataForOtherPlayers.c_str());
						sendMessage(buff, room->players[i]->socket);
					}
				}
			}
		}
		
		//Set null and reduce the number of players in room
		room->players[player->position] = NULL;
		room->numberOfPlayer--;

		//if don't have any players in room, reset room
		if (room->numberOfPlayer == 0) {
			room->roomMaster = NULL;
			room = NULL;
		}
		
		strcpy(session->buffer, "280 Leave room successfully.");
		log += "280";
		writeInLogFile(log);
		LeaveCriticalSection(&criticalSection);
	}

}

/* The signIn function handle login request from client
* @param session - LP_Session struct pointer manage user
* @param log - reference variable store the activity log
*  @param data - message without protocol send by client
* @return No return value
*/
void signUp(LP_Session session, string &log, string data) {
	char rs[DATA_BUFSIZE];
	memset(rs, 0, DATA_BUFSIZE);
	SQLHANDLE sqlStmtHandle;
	sqlStmtHandle = NULL;
	string strUsername = data.substr(0, data.find("\n"));
	string strPassword = data.substr(data.find("\n") + 1);
	string strIsLogin = "0";
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
			query = "INSERT INTO account VALUES ('" + strUsername + "','" + strPassword + "','" + strIsLogin + "')";
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

/* The signIn function handle login request from client
* @param session - LP_Session struct pointer manage user
* @param log - reference variable store the activity log 
*  @param data - message without protocol send by client
* @return No return value
*/

void signIn(LP_Session session, string &log, string data) {
	LP_Player player = session->player;
	char rs[DATA_BUFSIZE];
	memset(rs, 0, DATA_BUFSIZE);
	SQLHANDLE sqlStmtHandle;
	sqlStmtHandle = NULL;
	string strUsername = data.substr(0, data.find("\n"));
	string strPassword = data.substr(data.find("\n") + 1);
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
			//check already log in
			SQLINTEGER islogin;
			SQLINTEGER ptrSqlVersion;
			SQLGetData(sqlStmtHandle, 1, SQL_C_ULONG, &session->userID, SQL_RESULT_LEN, &ptrSqlVersion);
			SQLGetData(sqlStmtHandle, 4, SQL_C_LONG, &islogin, SQL_RESULT_LEN, &ptrSqlVersion);
			cout << "session -> userID " << session->userID << endl;
			if (islogin == 1) {
				log += "411";
				strcpy(session->buffer, "411 You logged in from a different location");
				writeInLogFile(log);
				SQLFreeHandle(SQL_HANDLE_STMT, sqlStmtHandle);
				return;
			}
			//login successfully
			strcat_s(rs, "210 Sign in success!");
			log += "210";
			strcpy(session->buffer, rs);
			session->isLogin = true;
			updateLoginStatus(strUsername, "1");
			strcpy(session->username, strUsername.c_str());
			player->userID = session->userID;
			player->roomID == "";
			strcpy(player->username, session->username);
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

/* The logOut function handle Log Out Request
* @param session - LP_Session struct pointer manage user
* @param log - reference variable store the activity log 
* @return No return value
*/
void logOut(LP_Session session, string &log) {
	char rs[DATA_BUFSIZE];
	memset(rs, 0, DATA_BUFSIZE);

	string username(session->username);
	updateLoginStatus(username, "0");
	strcat_s(rs, "220 Logout sucessfull!");
	log += "220";
	session->isLogin = false;
	memset(session->username, 0, USER_LEN);

	strcpy(session->buffer, rs);
	// Write in log file
	writeInLogFile(log);
}

/* The updateLoginStatus function update login status to database
* @param username - username
* @param isLogin - login status
* @return No return value
*/
void updateLoginStatus(string username, string isLogin) {
	string query = "UPDATE account SET islogin = '" + isLogin + "' WHERE username='" + username + "'";
	cout << query << endl;
	PWSTR lquery1 = convertStringToLPWSTR(query);
	SQLHANDLE sqlStmtHandle1;
	EnterCriticalSection(&criticalSection);
	sqlStmtHandle1 = handleQuery(sqlConnHandle, lquery1);
	SQLFetch(sqlStmtHandle1);
	LeaveCriticalSection(&criticalSection);
	SQLFreeHandle(SQL_HANDLE_STMT, sqlStmtHandle1);
}

/* The sendMessage function send message to client
* @param buff - message to sent
* @param connectedSocket - socket connect
* @return No return value
*/
void sendMessage(char *buff, SOCKET &connectedSocket) {

	int ret = send(connectedSocket, buff, strlen(buff), 0);
	if (ret == SOCKET_ERROR) {
		printf("Error %d: Can't send data.\n", WSAGetLastError());
	}
}

/* The writeInLogFile function write log to a file
* @param log - reference variable store the activity log
* @return No return value
*/
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

/* The convertStringToLPWSTR function convert string to LPWSTR
* @param param - string to convert
* @return LPWSTR
*/
LPWSTR convertStringToLPWSTR(string param) {
	wchar_t wquery[BUFF_QUERY];
	mbstowcs(wquery, param.c_str(), strlen(param.c_str()) + 1);
	LPWSTR lquery = wquery;
	return lquery;
}

/* The returnCurrentTime function get current time when user send message to server
* @param log - reference variable store the activity log
* @return No return value
*/
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

/* The gen_random function get random string with len characters
* @param len - length string
* @return random string with len characters 
*/
string gen_random(const int len) {
	string tmp_s;
	static const char alphanum[] =
		"0123456789"
		"ABCDEFGHIJKLMNOPQRSTUVWXYZ"
		"abcdefghijklmnopqrstuvwxyz";

	srand((unsigned)time(NULL) * getpid());

	tmp_s.reserve(len);

	for (int i = 0; i < len; ++i)
		tmp_s += alphanum[rand() % (sizeof(alphanum) - 1)];
	return tmp_s;

}



