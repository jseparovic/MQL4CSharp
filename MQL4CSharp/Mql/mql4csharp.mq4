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
int InitRates(MqlRates&[], int);
int InitCommandManager();
int ExecOnInit(string);

void SetRatesSize(int, int);
void ExecOnDeinit(int);
void ExecOnTick(int);
void ExecOnTimer(int);
bool IsExecutingOnTick(int);
bool IsCommandWaiting(int);
int GetCommandId(int);
void GetCommandName(int, string &cmdName);
void GetCommandParams(int, string &cmdParams);
void SetBoolCommandResponse(int, bool, int);
void SetDoubleCommandResponse(int, double, int);
void SetIntCommandResponse(int, int, int);
void SetStringCommandResponse(int, string, int);
void SetVoidCommandResponse(int, int);
void SetLongCommandResponse(int, long, int);
void SetDateTimeCommandResponse(int, datetime, int);
void SetEnumCommandResponse(int, int, int);
#import

 
int ratesSize;
MqlRates rates[];
int ratesIx;
int expertIx;
int commandManagerIx;
 
input string CSharpFullTypeName = "MQL4CSharp.UserDefined.Strategy.MaCrossStrategy"; 
 
char DELIM = 29;

void maintainRates(int ix)
{
   // update rates array size
   if(ratesSize != ArraySize(rates)) 
   {
      SetRatesSize(ix, ArraySize(rates));
   }
}


bool executeCommands(int ix)
{
   //Print("IsCommandWaiting(): " + IsCommandWaiting());      
   if(IsCommandWaiting(ix))
   {
      int id = GetCommandId(ix);
      string name = "";
      string params = "";
      GetCommandName(ix, name);
      GetCommandParams(ix, params);
      
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
         SetBoolCommandResponse(ix, boolresult, error);
      }
      else if(returnType == RETURN_TYPE_DOUBLE)
      {
         double doubleresult = executeDoubleCommand(id, paramArray);
         error = GetLastError();
         //Print ("command: " + name + ", params" + params + ", result: " + doubleresult + ", error: " + error);
         SetDoubleCommandResponse(ix, doubleresult, error);
      }
      else if(returnType == RETURN_TYPE_INT)
      {
         int intresult = executeIntCommand(id, paramArray);
         error = GetLastError();
         if(StringCompare(name, "OrdersTotal") == 0)
         {
            Print ("command: " + name + ", params" + params + ", result: " + intresult + ", error: " + error);
         }
         SetIntCommandResponse(ix, intresult, error);
      }
      else if(returnType == RETURN_TYPE_STRING)
      {
         string stringresult = executeStringCommand(id, paramArray);
         error = GetLastError();
         //Print ("command: " + name + ", params" + params + ", result: " + stringresult + ", error: " + error);
         SetStringCommandResponse(ix, stringresult, error);
      }
      else if(returnType == RETURN_TYPE_VOID)
      {
         executeVoidCommand(id, paramArray);
         //Print ("command: " + name + ", params" + params + ", error: " + error);
         SetVoidCommandResponse(ix, GetLastError());
      }
      else if(returnType == RETURN_TYPE_LONG)
      {
         long longresult = executeLongCommand(id, paramArray);
         error = GetLastError();
         //Print ("command: " + name + ", params" + params + ", result: " + longresult + ", error: " + error);
         SetLongCommandResponse(ix, longresult, error);
      }
      else if(returnType == RETURN_TYPE_DATETIME)
      {
         datetime datetimeresult = executeDateTimeCommand(id, paramArray);
         error = GetLastError();
         //Print ("command: " + name + ", params" + params + ", result: " + datetimeresult + ", error: " + error);
         SetDateTimeCommandResponse(ix, datetimeresult, error);
      }
      
      params = NULL;
      name = NULL;
      id = NULL;
   }
   return false;
}

int OnInit()
{
   EventSetMillisecondTimer(1);

   // Initialize log4net
   //Print("Initializing logging");
   InitLogging();
   
   // Copy the rates array and pass it to the library
   //Print("Initializing rates");
   ArrayCopyRates(rates,NULL,0);
   ratesSize = ArraySize(rates);
   ratesIx = InitRates(rates, ratesSize);

   expertIx = ExecOnInit(CSharpFullTypeName);
   
   commandManagerIx = InitCommandManager();

   // execute commands that are waiting
   executeCommands(commandManagerIx);
   
   return(INIT_SUCCEEDED);
}
 
void OnDeinit(const int reason)
{
   // Call the DLL onDeinit
   ExecOnDeinit(expertIx);
}
 
void OnTick()
{
   // Call the DLL onTick
   ExecOnTick(expertIx);

   // execute commands that are waiting
   while(IsExecutingOnTick(commandManagerIx))
   {
      executeCommands(commandManagerIx);
   }
      
   // Keep the rates array size up to date
   maintainRates(ratesIx);
}


void OnTimer()
{
   ExecOnTimer(expertIx);

   // execute commands that are waiting
   executeCommands(commandManagerIx);
}
