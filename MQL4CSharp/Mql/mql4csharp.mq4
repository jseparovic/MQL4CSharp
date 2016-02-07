/*
Copyright 2016 Jason Separovic

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

#include <mc_helpers.mqh>
#include <mc_funcs.mqh>
#include <mc_returns.mqh>


#import "MQL4CSharp.dll"
void InitLogging();
int ExecOnInit(long, string);
int InitRates(long, MqlRates&[], int);
void SetRatesSize(long, int);
void ExecOnDeinit(long);
void ExecOnTick(long);
void ExecOnTimer(long);
bool IsExecutingOnInit(long);
bool IsExecutingOnTick(long);
bool IsCommandManagerReady(long);
int IsCommandWaiting(long);
int GetCommandId(long, int);
void GetCommandName(long, int, string &cmdName);
void GetCommandParams(long, int, string &cmdParams);
void SetBoolCommandResponse(long, int, bool, int);
void SetDoubleCommandResponse(long, int, double, int);
void SetIntCommandResponse(long, int, int, int);
void SetStringCommandResponse(long, int, string, int);
void SetVoidCommandResponse(long, int, int);
void SetLongCommandResponse(long, int, long, int);
void SetDateTimeCommandResponse(long, int, datetime, int);
void SetEnumCommandResponse(long, int, int, int);
#import

 
int ratesSize;
MqlRates rates[];
long index;
 
input string CSharpFullTypeName = "MQL4CSharp.UserDefined.Strategy.MaCrossStrategy"; 
 
char DELIM = 29;

void maintainRates(long ix)
{
   // update rates array size
   if(ratesSize != ArraySize(rates)) 
   {
      SetRatesSize(ix, ArraySize(rates));
   }
}


bool executeCommands(long ix)
{
   //Print("IsCommandWaiting(): " + IsCommandWaiting(ix, requestId));
   int requestId;
   while((requestId = IsCommandWaiting(ix)) != -1)
   {
      int id = GetCommandId(ix, requestId);
      string name = "";
      string params = "";
      GetCommandName(ix, requestId, name);
      GetCommandParams(ix, requestId, params);
      
      //Print("name: " +  name);
      //Print("params: " +  params);

      // Parse the command
      string paramArray[];
      StringSplit(params, DELIM, paramArray);

      int returnType = getCommandReturnType(id);

      // reset last error
      ResetLastError();
      
      int error;
      if(returnType == RETURN_TYPE_BOOL)
      {
         bool boolresult = executeBoolCommand(id, paramArray);
         error = GetLastError();
         //Print ("command: " + name + ", params" + params + ", result: " + boolresult + ", error: " + error);
         SetBoolCommandResponse(ix, requestId, boolresult, error);
      }
      else if(returnType == RETURN_TYPE_DOUBLE)
      {
         double doubleresult = executeDoubleCommand(id, paramArray);
         error = GetLastError();
         //Print ("command: " + name + ", params" + params + ", result: " + doubleresult + ", error: " + error);
         SetDoubleCommandResponse(ix, requestId, doubleresult, error);
      }
      else if(returnType == RETURN_TYPE_INT)
      {
         int intresult = executeIntCommand(id, paramArray);
         error = GetLastError();
         //if(StringCompare(name, "OrdersTotal") == 0)
         //{
         //   Print ("command: " + name + ", params" + params + ", result: " + intresult + ", error: " + error);
         //}
         SetIntCommandResponse(ix, requestId, intresult, error);
      }
      else if(returnType == RETURN_TYPE_STRING)
      {
         string stringresult = executeStringCommand(id, paramArray);
         error = GetLastError();
         //Print ("command: " + name + ", params" + params + ", result: " + stringresult + ", error: " + error);
         SetStringCommandResponse(ix, requestId, stringresult, error);
      }
      else if(returnType == RETURN_TYPE_VOID)
      {
         executeVoidCommand(id, paramArray);
         //Print ("command: " + name + ", params" + params + ", error: " + error);
         SetVoidCommandResponse(ix, requestId, GetLastError());
      }
      else if(returnType == RETURN_TYPE_LONG)
      {
         long longresult = executeLongCommand(id, paramArray);
         error = GetLastError();
         //Print ("command: " + name + ", params" + params + ", result: " + longresult + ", error: " + error);
         SetLongCommandResponse(ix, requestId, longresult, error);
      }
      else if(returnType == RETURN_TYPE_DATETIME)
      {
         datetime datetimeresult = executeDateTimeCommand(id, paramArray);
         error = GetLastError();
         //Print ("command: " + name + ", params" + params + ", result: " + datetimeresult + ", error: " + error);
         SetDateTimeCommandResponse(ix, requestId, datetimeresult, error);
      }
   }
   return false;
}

int OnInit()
{
   EventSetMillisecondTimer(1);

   // Initialize log4net
   Print("Initializing logging");
   InitLogging();
   
   // Copy the rates array and pass it to the library
   ArrayCopyRates(rates, NULL, 0);
   ratesSize = ArraySize(rates);
   index = ChartID();
   Print("ExecOnInit: " + index + ", " + CSharpFullTypeName);
   ExecOnInit(index, CSharpFullTypeName);
   
   Print("Waiting for Command Manager");
   while(!IsCommandManagerReady(index))
   {
   
   }
   
   Print("executeCommands");
   while(IsExecutingOnInit(index))
   {
      executeCommands(index);
   }

   Print("Initializing rates");
   InitRates(index, rates, ratesSize);

   Print("OnInit complete");
   return(INIT_SUCCEEDED);
}
 
void OnDeinit(const int reason)
{
   // Call the DLL onDeinit
   ExecOnDeinit(index);
}
 
void OnTick()
{
   // Call the DLL onTick
   ExecOnTick(index);

   // execute commands that are waiting
   while(IsExecutingOnTick(index))
   {
      executeCommands(index);
   }
      
   // Keep the rates array size up to date
   maintainRates(index);
}


void OnTimer()
{
   ExecOnTimer(index);

   // execute commands that are waiting
   executeCommands(index);
}
