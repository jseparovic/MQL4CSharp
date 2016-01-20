

#import "mqlsharp.dll"
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
string SetBoolCommandResponse(bool, int);
#import
 
int ratesSize;
MqlRates rates[];
 
input string CSharpFullTypeName = "Mql4CSharp.Strategies.TestStrategy"; 
 
string DELIM = "|";

void maintainRates()
{
   // update rates array size
   if(ratesSize != ArraySize(rates)) 
   {
      SetRatesSize(ArraySize(rates));
   }
}

int getObjectType(string objectType)
{
   if(objectType == "OBJ_TREND")
   {
      return OBJ_TREND;
   }
   
   return -1;
}

bool executeBoolCommand(int id, string params[])
{
   switch(id)
   {
      case 1:
         return ObjectCreate(
                     StringToInteger(params[0]),
                     params[1],
                     getObjectType(params[2]),
                     StringToInteger(params[3]),
                     StringToTime(params[4]),
                     StringToDouble(params[5]),
                     StringToTime(params[6]),
                     StringToDouble(params[7]));
   }
}


int RETURN_TYPE_BOOL = 1;

int getCommandReturnType(int id)
{
   switch(id)
   {
      case 1:
         // ObjectCreate
         return RETURN_TYPE_BOOL;

      default:
         return -1;         
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
      StringSplit(params, StringGetCharacter(DELIM,0), paramArray);

      int returnType = getCommandReturnType(id);
      
      if(returnType == RETURN_TYPE_BOOL)
      {
         SetBoolCommandResponse(executeBoolCommand(id, paramArray), GetLastError());
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