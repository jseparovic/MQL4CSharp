#include <mc_helpers.mqh>
#include <mc_funcs.mqh>
#include <mc_returns.mqh>


#import "MQL4CSharp.dll"
void InitLogging();
void InitRates(MqlRates&[], int);
void SetRatesSize(int);
void ExecOnInit(string);
void ExecOnDeinit();
void ExecOnTick();
void ExecOnTimer();
bool IsCommandWaiting();
int GetCommandId();
string GetCommandName();
string GetCommandParams();
void SetBoolCommandResponse(bool, int);
void SetDoubleCommandResponse(double, int);
void SetIntCommandResponse(int, int);
void SetStringCommandResponse(string, int);
void SetVoidCommandResponse(int);
void SetLongCommandResponse(long, int);
void SetDateTimeCommandResponse(datetime, int);
void SetEnumCommandResponse(int, int);

#import
 
int ratesSize;
MqlRates rates[];
 
input string CSharpFullTypeName = "MQL4CSharp.UserDefined.Strategy.MaCrossStrategy"; 
 
char DELIM = 29;

void maintainRates()
{
   // update rates array size
   if(ratesSize != ArraySize(rates)) 
   {
      SetRatesSize(ArraySize(rates));
   }
}


void executeCommands()
{
   if(IsCommandWaiting())
   {
      int id = GetCommandId();
      string name = GetCommandName();
      string params = GetCommandParams();
      
      // Parse the command
      string paramArray[];
      StringSplit(params, DELIM, paramArray);

      int returnType = getCommandReturnType(id);
      
      if(returnType == RETURN_TYPE_BOOL)
      {
         SetBoolCommandResponse(executeBoolCommand(id, paramArray), GetLastError());
      }
      else if(returnType == RETURN_TYPE_DOUBLE)
      {
         SetDoubleCommandResponse(executeDoubleCommand(id, paramArray), GetLastError());
      }
      else if(returnType == RETURN_TYPE_INT)
      {
         SetIntCommandResponse(executeIntCommand(id, paramArray), GetLastError());
      }
      else if(returnType == RETURN_TYPE_STRING)
      {
         SetStringCommandResponse(executeStringCommand(id, paramArray), GetLastError());
      }
      else if(returnType == RETURN_TYPE_VOID)
      {
         executeVoidCommand(id, paramArray);
         SetVoidCommandResponse(GetLastError());
      }
      else if(returnType == RETURN_TYPE_LONG)
      {
         SetLongCommandResponse(executeLongCommand(id, paramArray), GetLastError());
      }
      else if(returnType == RETURN_TYPE_DATETIME)
      {
         SetDateTimeCommandResponse(executeDateTimeCommand(id, paramArray), GetLastError());
      }
   }
}

int OnInit()
{
   // Initialize log4net
   InitLogging();
   
   // Copy the rates array and pass it to the library
   ArrayCopyRates(rates,NULL,0);
   ratesSize = ArraySize(rates);
   InitRates(rates, ratesSize);

   EventSetMillisecondTimer(1);

   // Call the DLL onInit
   ExecOnInit(CSharpFullTypeName);
   
   return(INIT_SUCCEEDED);
}
 
void OnDeinit(const int reason)
{
   // Call the DLL onDeinit
   ExecOnDeinit();
}
 
void OnTick()
{
   // Keep the rates array size up to date
   maintainRates();
   
   // Call the DLL onTick
   ExecOnTick();
}


void OnTimer()
{
   // execute commands that are waiting
   executeCommands();
   
   ExecOnTimer();
}

