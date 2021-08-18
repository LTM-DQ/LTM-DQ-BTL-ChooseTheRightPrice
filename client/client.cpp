#include "stdafx.h"
#include "winsock2.h"
#include "Ws2tcpip.h"
#include "string"
#include "iostream"

using namespace std;

#pragma comment(lib, "Ws2_32.lib")
#pragma warning(disable:4996)

#define DELIMITER "\r\n"
#define BUFF_SIZE 2048

SOCKET clientSock;
sockaddr_in serverAddr;
char buff[BUFF_SIZE], buffIn[BUFF_SIZE];
int ret;

// Initiate Winsock
void initiateWinsock() {

	WSADATA wsaData;
	WORD version = MAKEWORD(2, 2);
	if (WSAStartup(version, &wsaData)) {
		printf("Winsock 2 is not supported\n");
		exit(0);
	}
}

// Construct socket
void constructSocket() {

	clientSock = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (clientSock == INVALID_SOCKET) {
		printf("Error %d: Cannot create client socket", WSAGetLastError());
		exit(0);
	}
}

// Request connect to server
void requestConnectToServer(char *serverIP, char *serverPort) {
	// Specify server address
	serverAddr.sin_family = AF_INET;
	serverAddr.sin_port = htons(atoi(serverPort));
	inet_pton(AF_INET, serverIP, &serverAddr.sin_addr);

	// Request connect to server
	if (connect(clientSock, (sockaddr *)&serverAddr, sizeof(serverAddr))) {
		printf("Error %d: Cannot connect server.", WSAGetLastError());
		exit(0);
	}

	printf("Connected Server!\n");
}

// Send message to server
void sendMessage(char *buff, int messageLength) {
	messageLength = strlen(buff);
	int index = 0;
	// Handle byte stream
	while (messageLength > 0) {
		memcpy(buff, buff + index, messageLength);
		ret = send(clientSock, buff, messageLength, 0);
		if (ret == SOCKET_ERROR) {
			printf("Error %d: Cannot send data.\n", WSAGetLastError());
		}
		messageLength -= ret;
		index += ret;
	}
}
// Receive message and echo message from server
void recvMessage(char *buff) {
	ret = recv(clientSock, buff, BUFF_SIZE, 0);
	if (ret == SOCKET_ERROR) {
		printf("Error %d: Cannot receive data.\n", WSAGetLastError());

	}
	else if (strlen(buff) > 0) {
		buff[ret] = 0;
		cout << buff << endl;
		string str = buff;
		cout << str.substr(4) << endl;
		cout << endl;
	}
}

// signin function
void signin() {
	while (1) {
		memset(buff, 0, BUFF_SIZE);
		memset(buffIn, 0, BUFF_SIZE);
		// Enter string
		printf("To back to menu, please press enter!\n");
		printf("Please enter username!\n\n");
		printf("username: ");
		gets_s(buffIn, BUFF_SIZE);

		if (strlen(buffIn) == 0) break;
		strcat_s(buff, "SIGNIN ");
		strcat_s(buff, buffIn);

		printf("Please enter password!\n\n");
		printf("password: ");
		gets_s(buffIn, BUFF_SIZE);

		strcat_s(buff, "\n");
		strcat_s(buff, buffIn);
		strcat_s(buff, DELIMITER);

		// Send message
		sendMessage(buff, strlen(buff));
		// Receive message
		recvMessage(buff);
		string recvData = buff;
		string key = recvData.substr(0, 3);
		if (key == "210") break;
		else if (key == "401") break;
	}
}

// signup function
void signup() {
	memset(buff, 0, BUFF_SIZE);
	memset(buffIn, 0, BUFF_SIZE);
	// Enter string
	printf("To back to menu, please press enter!\n");
	printf("Please enter username!\n\n");
	printf("username: ");
	gets_s(buffIn, BUFF_SIZE);

	if (strlen(buffIn) == 0) return;
	strcat_s(buff, "SIGNUP ");
	strcat_s(buff, buffIn);

	printf("Please enter password!\n\n");
	printf("password: ");
	gets_s(buffIn, BUFF_SIZE);

	strcat_s(buff, "\n");
	strcat_s(buff, buffIn);
	strcat_s(buff, DELIMITER);

	// Send message
	sendMessage(buff, strlen(buff));
	// Receive message
	recvMessage(buff);
	string recvData = buff;
	string key = recvData.substr(0, 3);
}

// Log out function
void logOut() {
	memset(buff, 0, BUFF_SIZE);
	strcat_s(buff, "LOGOUT");
	strcat_s(buff, DELIMITER);

	// Send message
	sendMessage(buff, strlen(buff));
	// Receive message
	recvMessage(buff);
}

// Log out function
void createRoom() {
	memset(buff, 0, BUFF_SIZE);
	strcat_s(buff, "CREATE");
	strcat_s(buff, DELIMITER);

	// Send message
	sendMessage(buff, strlen(buff));
	// Receive message
	recvMessage(buff);
}

void gointoRoomById() {
	memset(buff, 0, BUFF_SIZE);
	memset(buffIn, 0, BUFF_SIZE);
	cout << "Enter room ID : ";
	gets_s(buffIn, BUFF_SIZE);
	if (strlen(buffIn) == 0) return;
	strcat_s(buff, "GOINTO ");
	strcat_s(buff, buffIn);
	strcat_s(buff, DELIMITER);
	cout << buff << endl;
	// Send message
	sendMessage(buff, strlen(buff));
	// Receive message
	recvMessage(buff);
	recvMessage(buff);
}

void gointoRoomAtRandom() {
	memset(buff, 0, BUFF_SIZE);
	strcat_s(buff, "GOINTO ");
	strcat_s(buff, DELIMITER);
	// Send message
	sendMessage(buff, strlen(buff));
	// Receive message
	recvMessage(buff);
}

void exitRoom() {
	memset(buff, 0, BUFF_SIZE);
	strcat_s(buff, "EXITRM");
	strcat_s(buff, DELIMITER);
	// Send message
	sendMessage(buff, strlen(buff));
	// Receive message
	recvMessage(buff);
}

// start game
void startGame() {
	memset(buff, 0, BUFF_SIZE);
	strcat_s(buff, "STARTT");
	strcat_s(buff, DELIMITER);

	// Send message
	sendMessage(buff, strlen(buff));
	// Receive message
	recvMessage(buff);
}

// get quiz
void getQuiz() {
	memset(buff, 0, BUFF_SIZE);
	strcat_s(buff, "QUIZZZ");
	strcat_s(buff, DELIMITER);

	// Send message
	sendMessage(buff, strlen(buff));
	// Receive message
	recvMessage(buff);
}

void answerQuestion() {
	// Check login
	memset(buff, 0, BUFF_SIZE);
	memset(buffIn, 0, BUFF_SIZE);
	// Enter String
	cout << "To back to menu, please press enter!" << endl;
	cout << "Enter message!\n\n";
	cout << "ANSWER: ";
	gets_s(buffIn, BUFF_SIZE);

	if (strlen(buffIn) == 0) return;
	strcat_s(buff, "ANSWER ");
	strcat_s(buff, buffIn);
	strcat_s(buff, DELIMITER);

	// Send message
	sendMessage(buff, strlen(buff));
	// Receive message
	recvMessage(buff);
}

// Menu function
void menu() {
	while (1) {
		// display menu
		printf("1. Sign in\n2. Sign up\n3. Logout\n4. Create Room\n5.Go into the room by roomcode\n");
		printf("6.Go into the room at random\n7.Leave the room\n8. get quiz\n9. Start game\n10. Enter answer\n");
		printf("11. Exit\n");
		printf("Choose a function: ");
		char choose[BUFF_SIZE];
		// choose a function
		gets_s(choose, BUFF_SIZE);
		switch (atoi(choose)) {
		case 1:
			signin();
			break;
		case 2:
			signup();
			break;
		case 3:
			logOut();
			break;
		case 4:
			createRoom();
			break;
		case 5:
			gointoRoomById();
			break;
		case 6:
			gointoRoomAtRandom();
			break;
		case 7: 
			exitRoom();
			break;
		case 8:
			getQuiz();
			break;
		case 9:
			startGame();
			break;
		case 10:
			answerQuestion();
			break;
		case 11:
			closesocket(clientSock);
			WSACleanup();
			exit(1);
		default:
			printf("Enter error: please enter again!\n\n");
			break;
		}
	}
}

int main(int argc, char *argv[])
{
	// Command-Line Arguments
	if (argc < 3) {
		printf("Enter error, please enter like this: client.exe 127.0.0.1 5500");
		return 0;
	}
	char *serverIP = argv[1];
	char *serverPort = argv[2];

	initiateWinsock();
	constructSocket();
	requestConnectToServer(serverIP, serverPort);
	menu();

	// Close socket
	closesocket(clientSock);

	// Terminate winsock
	WSACleanup();

	return 0;
}
