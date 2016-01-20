# MQL4CSharp
##CSharp Library for Metatrader 4

This library is not complete, however it demonstrates a framework for calling MQL4 commands from within a C# class.

Basically, the CommandManager will handle one command at a time and will only ever be called from the Base Strategy which is in it's own thread.
The "command" should set the ID, and parameters, then MQL4 will detect a command ready to be called (it is currently checking every millisecond in OnTimer), then it will parse it, execute it, and set the result.
The original command called from the custom strategy in C# will then be returned once it detects a result has been set.

The basic workflow => https://i.imgur.com/8yvFxz1.png

Mql4CSharp.Strategies.TestStrategy shows as example of creating a trendline in the call to onInit.

Currently the following methods are supported:
  - ObjectCreate
  
More to come as needed for my own system development

To implement a strategy, you just extend the Strategy class and implement the abstract methods.

I'll be adding trade functions to this shortly:
  - getStopLoss
  - getTakeProfit
  - getEntryPrice
  - getExpiry
  - getLotSize
  - getComment
  - getMagicNumber
  - manageOpenTrades
  
Also, I will be adding the following abstract Types to try and keep logic for the above methods, somewhat separate and reusable:
  - UserSignal
  - UserStopLoss
  - UserTakeProfit
  - UserFilter
  - UserRiskProfile
  

## Installation Notes:
- Modify the build output path in MQL4CSharp properties in Visual Studio 2015 to match you metatrader terminal library directory (in mt4: file->open data folder)
- You need to copy log4net.dll. log4net.config and SmartThreadPool.dll to you metatrader root directory where the terminal.exe resides.
- Grab the mq4 file from https://github.com/jseparovic/MQL4CSharp/blob/master/MQL4CSharp/Mql/mql4csharp.mq4
- C# logging to file as per log4net.config
 

## Check out here for adding to this project:
https://github.com/jseparovic/MQL4CSharp/wiki/Adding-a-MQL4-Function-to-the-Framework

