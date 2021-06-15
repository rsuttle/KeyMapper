#include "pch.h"
#include <iostream>
#include <Windows.h>
#include <fstream>
#include "Source.h"
#include <boost/asio.hpp>

#define END_OF_FILE "<EOF>";

using boost::asio::ip::tcp;
using std::string;
using std::cout;
using std::endl;

HHOOK kbHook = NULL;

static LRESULT CALLBACK MouseProc(int nCode, WPARAM wParam, LPARAM lParam);
static LRESULT CALLBACK KeyboardProc(int code, WPARAM wParam, LPARAM lParam);

//Called when process receives a mouse input message
LRESULT CALLBACK MouseProc(int nCode, WPARAM wParam, LPARAM lParam) {

	return CallNextHookEx(NULL, nCode, wParam, lParam);
}

 std::vector<string> split(string s) {
	std::vector<string> tokens;
	string token;

	for (const auto& c : s) {
		if (!isspace(c))
			token += c;
		else {
			if (token.length()) tokens.push_back(token);
			token.clear();
		}
	}

	if (token.length()) tokens.push_back(token);
	return tokens;
}

//Called when process receives a keyboard input message
static LRESULT CALLBACK KeyboardProc(int code, WPARAM wParam, LPARAM lParam) {
	if (code < 0)
	{
		return CallNextHookEx(kbHook, code, wParam, lParam);
	}

	HWND program = GetForegroundWindow();

	std::ofstream logWriter;
	logWriter.open("C:\\Users\\Ryan\\Documents\\testingdlloutput\\kboutputcodes.txt", std::ofstream::app);

	int virtualKeyCode = wParam;
	std::string pressDirection = "";
	int vCodeToSendThrough = wParam;

	if (((long long) 1 << 31) & lParam) {
		pressDirection = "up";
	}
	else {
		pressDirection = "down";
	}

	boost::asio::io_service ioService;
	tcp::socket socket(ioService);
	socket.connect(tcp::endpoint(boost::asio::ip::address::from_string("192.168.0.5"), 9000));

	const string message = std::to_string(virtualKeyCode)+" "+pressDirection+END_OF_FILE;
	boost::system::error_code error;
	boost::asio::write(socket, boost::asio::buffer(message), error);
	if (error) {
		logWriter << "Error: " << error;
	}

	boost::asio::streambuf receiveBuffer;
	boost::asio::read(socket, receiveBuffer, boost::asio::transfer_all(), error);
	if (error && error != boost::asio::error::eof) {
		logWriter << "Failed to receive message from server: " << error.message() << "\n";
	}
	else {
		string msgFromServer = boost::asio::buffer_cast<const char*>(receiveBuffer.data());
		logWriter << "\n";
		logWriter << "Full message from server: "<<msgFromServer;
		std::vector<string> splitMsg = split(msgFromServer);
		
		string msgType = splitMsg[0];

		if (msgType == "Ok") {
			return CallNextHookEx(kbHook, code, wParam, lParam);
		}
		else if (msgType == "Single") {
			vCodeToSendThrough = std::stoi(splitMsg[1]);
			logWriter << "\n";
			logWriter << "Code to send through: " << vCodeToSendThrough;
			//PostMessage(program, WM_KEYDOWN, vCodeToSendThrough, lParam);
			//PostMessage(program, WM_KEYDOWN,0x11, lParam);
			//PostMessage(program, WM_KEYDOWN, 0x12, lParam);
			//PostMessage(program, WM_KEYDOWN, 0x2e, lParam);

			INPUT inputs[6] = {};
			ZeroMemory(inputs, sizeof(inputs));

			inputs[0].type = INPUT_KEYBOARD;
			inputs[0].ki.wVk = 0x11;

			inputs[1].type = INPUT_KEYBOARD;
			inputs[1].ki.wVk = 0x12;

			inputs[2].type = INPUT_KEYBOARD;
			inputs[2].ki.wVk = 0x2e;

			inputs[3].type = INPUT_KEYBOARD;
			inputs[3].ki.wVk = 0x11;
			inputs[3].ki.dwFlags = KEYEVENTF_KEYUP;

			inputs[4].type = INPUT_KEYBOARD;
			inputs[4].ki.wVk = 0x12;
			inputs[4].ki.dwFlags = KEYEVENTF_KEYUP;

			inputs[5].type = INPUT_KEYBOARD;
			inputs[5].ki.wVk = 0x2e;
			inputs[5].ki.dwFlags = KEYEVENTF_KEYUP;

			UINT uSent = SendInput(ARRAYSIZE(inputs), inputs, sizeof(INPUT));
			
			return 1;
		}
		else if (msgType == "Multi") {
			//do things
		}
	}

	return CallNextHookEx(kbHook,code,wParam,lParam);
	
}

extern "C" int __declspec(dllexport) setGlobalKeyboardHook() {
	kbHook = SetWindowsHookEx(WH_KEYBOARD, KeyboardProc, globalDllHandle, 0);
	if (kbHook == NULL) return -1;
	return 0;
}

extern "C" int __declspec(dllexport) removeGlobalKeyboardHook() {
	return 0;
}