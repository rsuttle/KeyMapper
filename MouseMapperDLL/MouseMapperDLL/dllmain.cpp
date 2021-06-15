// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#include <Windows.h>
#include <memory.h>
#include <iostream>
#include <fstream>

HINSTANCE globalDllHandle = NULL;

BOOL APIENTRY DllMain(HINSTANCE hinstDLL, DWORD reasonForCalling, LPVOID lpReserved) {
	switch (reasonForCalling) {
	case DLL_PROCESS_ATTACH:
	{
		if (globalDllHandle == NULL) {
			globalDllHandle = hinstDLL;
		}
		break;
	}
	case DLL_PROCESS_DETACH:
		break;
	default:
		//Shouldn't happen
		break;
	}

	return TRUE;
}

