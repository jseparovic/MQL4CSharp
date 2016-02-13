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
bool IsExecutingOnTimer(long);
bool IsExecutingOnDeinit(long);
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
bool CommandLock(long);
bool CommandUnlock(long);
#import

 
int ratesSize;
MqlRates rates[];
long chartID;
 
input string CSharpFullTypeName = "MQL4CSharp.UserDefined.Strategy.MaCrossStrategy"; 

int INFO = 3;
int DEBUG = 4;
int TRACE = 5;

int LOGLEVEL = INFO;
 
char DELIM = 29;

int DEFAULT_CHART_ID = 0;

int EVENT_TIMER_MILLIS = 1;

void maintainRates(long ix)
{
   // update rates array size
   if(ratesSize != ArraySize(rates)) 
   {
      SetRatesSize(ix, ArraySize(rates));
   }
}

void info(string m1, string m2 = "", string m3 = "", string m4 = "", string m5 = "", string m6 = "", string m7 = "", string m8 = "", string m9 = "", string m10 = "")
{
   if(LOGLEVEL >= INFO)
   {
      Print(StringTrimRight(StringFormat("[INFO] %s %s %s %s %s %s %s %s %s %s", m1,m2,m3,m4,m5,m6,m7,m8,m9,m10)));
   }
}

void debug(string m1, string m2 = "", string m3 = "", string m4 = "", string m5 = "", string m6 = "", string m7 = "", string m8 = "", string m9 = "", string m10 = "")
{
   if(LOGLEVEL >= DEBUG)
   {
      Print(StringTrimRight(StringFormat("[DEBUG] %s %s %s %s %s %s %s %s %s %s", m1,m2,m3,m4,m5,m6,m7,m8,m9,m10)));
   }
}

void trace(string m1, string m2 = "", string m3 = "", string m4 = "", string m5 = "", string m6 = "", string m7 = "", string m8 = "", string m9 = "", string m10 = "")
{
   if(LOGLEVEL >= TRACE)
   {
      Print(StringTrimRight(StringFormat("[TRACE] %s %s %s %s %s %s %s %s %s %s", m1,m2,m3,m4,m5,m6,m7,m8,m9,m10)));
   }
}

bool executeCommands(long ix)
{
   trace("IsCommandWaiting(): " + IsCommandWaiting(ix));
   int requestId;
   while((requestId = IsCommandWaiting(ix)) != -1)
   {
      debug("Executing Commands");
      if(CommandLock(ix))
      {
         debug("Locked");
         int id = GetCommandId(ix, requestId);
         string name = "";
         string params = "";
         GetCommandName(ix, requestId, name);
         GetCommandParams(ix, requestId, params);
         
         debug("name: " +  name);
         debug("params: " +  params);
   
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
            trace ("command: " + name + ", params" + params + ", result: " + boolresult + ", error: " + error);
            SetBoolCommandResponse(ix, requestId, boolresult, error);
         }
         else if(returnType == RETURN_TYPE_DOUBLE)
         {
            double doubleresult = executeDoubleCommand(id, paramArray);
            error = GetLastError();
            trace ("command: " + name + ", params" + params + ", result: " + doubleresult + ", error: " + error);
            SetDoubleCommandResponse(ix, requestId, doubleresult, error);
         }
         else if(returnType == RETURN_TYPE_INT)
         {
            int intresult = executeIntCommand(id, paramArray);
            error = GetLastError();
            trace ("command: " + name + ", params" + params + ", result: " + intresult + ", error: " + error);
            SetIntCommandResponse(ix, requestId, intresult, error);
         }
         else if(returnType == RETURN_TYPE_STRING)
         {
            string stringresult = executeStringCommand(id, paramArray);
            error = GetLastError();
            trace ("command: " + name + ", params" + params + ", result: " + stringresult + ", error: " + error);
            SetStringCommandResponse(ix, requestId, stringresult, error);
         }
         else if(returnType == RETURN_TYPE_VOID)
         {
            executeVoidCommand(id, paramArray);
            trace ("command: " + name + ", params" + params + ", error: " + error);
            SetVoidCommandResponse(ix, requestId, GetLastError());
         }
         else if(returnType == RETURN_TYPE_LONG)
         {
            long longresult = executeLongCommand(id, paramArray);
            error = GetLastError();
            trace ("command: " + name + ", params" + params + ", result: " + longresult + ", error: " + error);
            SetLongCommandResponse(ix, requestId, longresult, error);
         }
         else if(returnType == RETURN_TYPE_DATETIME)
         {
            datetime datetimeresult = executeDateTimeCommand(id, paramArray);
            error = GetLastError();
            trace ("command: " + name + ", params" + params + ", result: " + datetimeresult + ", error: " + error);
            SetDateTimeCommandResponse(ix, requestId, datetimeresult, error);
         }
      
         debug("Unlocking");
         CommandUnlock(ix);
         debug("Unlocked");
      }   

   }
   return false;
}



int OnInit()
{
   EventSetMillisecondTimer(EVENT_TIMER_MILLIS);

   // Initialize log4net
   info("OnInit() Initializing logging");
   InitLogging();
   
   // Copy the rates array and pass it to the library
   ArrayCopyRates(rates, NULL, 0);
   ratesSize = ArraySize(rates);
   chartID = ChartID();
   info("OnInit() ExecOnInit: ", chartID, ", ", CSharpFullTypeName);
   ExecOnInit(chartID, CSharpFullTypeName);
   
   info("OnInit() Waiting for Command Manager");
   while(!IsCommandManagerReady(chartID))
   {
   
   }
   
   info("OnInit() executeCommands on Init");
   while(IsExecutingOnInit(chartID))
   {
      trace("OnInit() IsExecutingOnInit(chartID)");
      executeCommands(chartID);
   }
   
   // execute default REST commands
   info("OnInit() executeCommands REST");
   executeCommands(DEFAULT_CHART_ID);
   
   info("OnInit() Initializing rates");
   InitRates(chartID, rates, ratesSize);

   info("OnInit() OnInit complete");
   return(INIT_SUCCEEDED);
}
 
void OnDeinit(const int reason)
{
   // Call the DLL onDeinit
   ExecOnDeinit(chartID);
   
   // execute commands that are waiting
   while(IsExecutingOnDeinit(chartID))
   {
      executeCommands(chartID);
   }
   
   // execute default REST commands
   executeCommands(DEFAULT_CHART_ID);
}

 
void OnTick()
{
   // Call the DLL onTick
   ExecOnTick(chartID);

   // execute commands that are waiting
   while(IsExecutingOnTick(chartID))
   {
      executeCommands(chartID);
   }

   // execute default REST commands
   executeCommands(DEFAULT_CHART_ID);
      
   // Keep the rates array size up to date
   maintainRates(chartID);
}


void OnTimer()
{
   ExecOnTimer(chartID);

   // execute commands that are waiting
   while(IsExecutingOnTimer(chartID))
   {
      executeCommands(chartID);
   }
   
   // execute default REST commands
   executeCommands(DEFAULT_CHART_ID);
}
