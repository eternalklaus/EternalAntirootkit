#include <ntifs.h>

#define EXCEPTION_ACCESS_VIOLATION 0xC0000005
#define BYTE unsigned char
#define DWORD unsigned long
#define PDWORD unsigned long*

ULONG offset_ActiveProcessLinks, offset_UniqueProcessId, offset_HandleTable, offset_ImageFileName, offset_HandleTable_HandleTableList, offset_HandleTable_UniqueProcessId;



offset_ActiveProcessLinks=0x88;
offset_UniqueProcessId=0x84;
offset_HandleTable=0xc4; //디버그 상에서 ObjectTable으로 표시된다.
offset_ImageFileName=0x174;
offset_HandleTable_HandleTableList=0x1c;
offset_HandleTable_UniqueProcessId=0x8;


typedef struct This_is_hidden_Process 
{
 PCHAR name;
 PDWORD pid;
 BYTE flag;
}THIS_IS_HIDDEN_PROCESS;


THIS_IS_HIDDEN_PROCESS process_found[100]; // 100개의 hidden process 탐지가 가능하다.
int gloopsize;

int FindPIDandCompare()
{
 PEPROCESS eprocess, temp_eprocess;
 PLIST_ENTRY ProcList_HandleTableList, hTableList, ProcList_ActiveProcessLinks, temp_ProcList_ActiveProcessLinks;
 PDWORD eproc_pid = NULL;
 PCHAR table_name, eproc_name; 
 
 int i = 0, num_exist = 0;
 eprocess = PsGetCurrentProcess(); // 현재 process context를 얻기 위해 사용한다. 이제 순회한다~~
 
 ProcList_HandleTableList = (PLIST_ENTRY)((*(PDWORD)((DWORD)eprocess + offset_HandleTable)) + offset_HandleTable_HandleTableList); //HandleTableList를 이용한 프로세스 조회
 ProcList_ActiveProcessLinks = (PLIST_ENTRY)((DWORD)eprocess + offset_ActiveProcessLinks); //ActiveProcessLinks를 이용한 프로세스 조회
 temp_ProcList_ActiveProcessLinks = ProcList_ActiveProcessLinks;
 
 // HandleTableList를 순회한다.
 for(hTableList = ProcList_HandleTableList, i = 0; hTableList->Flink != ProcList_HandleTableList; hTableList = hTableList->Flink, i++) 
 { 
  process_found[i].pid = (PDWORD)(((DWORD)hTableList - offset_HandleTable_HandleTableList) + offset_HandleTable_UniqueProcessId); 
  // ActiveProcessLinks를 순회한다.
  for(temp_ProcList_ActiveProcessLinks = ProcList_ActiveProcessLinks;  temp_ProcList_ActiveProcessLinks->Flink != ProcList_ActiveProcessLinks; temp_ProcList_ActiveProcessLinks = temp_ProcList_ActiveProcessLinks->Flink)
  {
   eproc_name = (PCHAR)(((DWORD)temp_ProcList_ActiveProcessLinks - offset_ActiveProcessLinks) + offset_ImageFileName);
   eproc_pid = (PDWORD)(((DWORD)temp_ProcList_ActiveProcessLinks - offset_ActiveProcessLinks) + offset_UniqueProcessId);
   
   //구조체를 설정하고, 이름과 PID를 저장한다. 이러던 도중 하나라도 일치하는 Process가 나오면 flag가 1이되며 루틴이 종료된다. 
   if((*eproc_pid) != (*(process_found[i].pid))) //(ActiveProcessLinks를 이용하여 찾은 pid) != (HandleTableList를 이용하여 찾은 pid) 이라면 --> 프로세스가 ActiveProcessLinks에 존재하지 않음을 의미한다.
   {
    //PsLookupProcessByProcessId 함수를 사용하여 PID에 해당하는 EPROCESS를 찾는다.
    PsLookupProcessByProcessId((HANDLE)(*(process_found[i].pid)), &temp_eprocess);
    process_found[i].flag = 0; //플래그를 0으로 설정한다. 
    process_found[i].name = (PCHAR)((DWORD)temp_eprocess + offset_ImageFileName); //프로세스의 이름을 넣어준다.
    //커널 오브젝트는 포인터가 참조하게되면 AccessPoint가 증가하여 프로세스가 종료되더라도 없어지지 않는다!! 따라서 참조카운터 수를 줄여주도록 한다.
    ObDereferenceObject(temp_eprocess);
   }
   else
   {
    process_found[i].flag = 1;//(ActiveProcessLinks를 이용하여 찾은 pid) != (HandleTableList를 이용하여 찾은 pid) 이라면 플래그를 1로 셋팅한다. 
    break; //해당 서브루틴을 종료하고, 본루틴으로 돌아간다. 
   }
  }
 }
 gloopsize = i; //최대 프로세스의 갯수
 for(i = 0; i < gloopsize; i++)
 {
  if(process_found[i].flag == 0) //플래그가 0이라면, 해당 프로세스는 은닉되었음을 의미한다. 
  {
   __try
   {
	DbgPrint("은닉된 프로세스 발견! [%d] %s \n", process_found[i].name, *(process_found[i].pid)) // 루트킷 발견시 디버그메시지로 뿌려준다.
    num_exist++; //은닉된 프로세스의 개수
   }
   __except(GetExceptionCode() == EXCEPTION_ACCESS_VIOLATION? EXCEPTION_EXECUTE_HANDLER : EXCEPTION_CONTINUE_SEARCH)
   {
    DbgPrint("processid : NULL\n");
   }
   
  } 
 }
 if(num_exist == 0)
 {
  DbgPrint("There are not exist hidden process!!\n");
 }
 return num_exist;
}
VOID RestoreProcess() //은닉된 프로세스를 보이게 복구한다. 
{
 PEPROCESS eprocess, eprocess_hidden;
 PLIST_ENTRY ProcList_ActiveProcessLinks, ProcList_Hidden;
 int nloop = 0;
 eprocess = PsGetCurrentProcess(); //eprocess는 현재 프로세스의 EPROCESS 구조체이다 
 ProcList_ActiveProcessLinks = (PLIST_ENTRY)((DWORD)eprocess + offset_ActiveProcessLinks); //현재 프로세스의 ActiveProcessLinks를 구한다. 
 for(nloop = 0; nloop < gloopsize; nloop++)
 {
  if(process_found[nloop].flag == 0) //은닉된 프로세스라면 flag가 0이다. 
  {  
   __try
   {
    PsLookupProcessByProcessId((HANDLE)(*(process_found[nloop].pid)), &eprocess_hidden); //process_found의 pid를 가지는 eprocess구조체를 구한다. 
    ProcList_Hidden = (PLIST_ENTRY)((DWORD)eprocess_hidden + offset_ActiveProcessLinks); //process_found의 ActiveProcessLinks를 구한다. 
    ProcList_Hidden->Flink = ProcList_ActiveProcessLinks->Flink; //현재 프로세스의 앞에다가 붙여준다.
    ProcList_Hidden->Blink = ProcList_ActiveProcessLinks->Flink->Blink; //현재 프로세스가 ProcList_Hidden의 뒤에 붙는다. 
    ProcList_ActiveProcessLinks->Flink->Blink = ProcList_Hidden;
    ProcList_ActiveProcessLinks->Flink = ProcList_Hidden;
   }
   __except(GetExceptionCode() == EXCEPTION_ACCESS_VIOLATION? EXCEPTION_EXECUTE_HANDLER : EXCEPTION_CONTINUE_SEARCH) //TODO: 꼭 필요한 코드인가?
   {
    ProcList_Hidden->Flink = ProcList_Hidden->Flink->Flink;
   }
   ObDereferenceObject(eprocess_hidden); //역시 참조 횟수를 줄여준다. 
  }
 }
 DbgPrint("Restore Clear\n");
}

VOID Unload(PDRIVER_OBJECT pDriverObject)
{
 DbgPrint("Driver Unload\n");
}
NTSTATUS DriverEntry(IN PDRIVER_OBJECT pDriverObject, IN PUNICODE_STRING pRegPath)
{
 int num_exist = 0;
 pDriverObject->DriverUnload = Unload;
 num_exist = FindPIDandCompare();
 if(num_exist > 0)
 {
  DbgPrint("[%d] 개의 은닉된 프로세스 발견!\n");
  RestoreProcess();
 }
 return STATUS_SUCCESS;
}