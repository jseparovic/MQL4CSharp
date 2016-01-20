

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
string SetBoolCommandResponse(bool, int);
#import
 
int ratesSize;
MqlRates rates[];
 
input string CSharpFullTypeName = "Mql4CSharp.Strategies.TestStrategy"; 
 
char DELIM = 29;

void maintainRates()
{
   // update rates array size
   if(ratesSize != ArraySize(rates)) 
   {
      SetRatesSize(ArraySize(rates));
   }
}

// TODO: add the rest of the objectTypes
int getObjectType(string objectType)
{
   if(objectType == "OBJ_TREND")
   {
      return OBJ_TREND;
   }
   
   return -1;
}

// TODO: add the rest of the MQL functions that return bool
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

// TODO: add more "execute[ReturnType]Command" methods for other return types


// TODO: Add more return types here
int RETURN_TYPE_BOOL = 1;


// TODO: and here
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
      StringSplit(params, DELIM, paramArray);

      int returnType = getCommandReturnType(id);

	  // TODO: add other return type method here      
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