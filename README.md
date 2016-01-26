# MQL4CSharp
##C# Library for Metatrader 4

This library is currently a work in progress. 
It demonstrates a framework for calling MQL4 commands from within a C# class.

When a command from a C# Strategy is called, it sets a flag which the MQL expert is polling every millisecond within it's onTimer() function. As the C# Strategy code is called in it's own thread, it will not block the MQL code, and the MQL function can execute while the C# function waits for the result. When the MQL expert detects a command waiting, parses it, executes it and sets the result and error code. The C# base strategy polls for the result every millisecond, so as soon as the result is set by MQL, the C# function will then return with the result.

In initial tests, 1 millisecond polling does not show any performance impacts to the system. 1000 bool tests every second for a 4GHz CPU isn't much theoretically. So performance here should be pretty much the same as running the code directly in MQL. This will be configurable.

The basic workflow => https://i.imgur.com/8yvFxz1.png

I mainly started this project as a way to get decent backtesting performance in MT4 whilst using a mainstream language. I picked C# due to simplicity.

https://github.com/jseparovic/MQL4CSharp/blob/master/MQL4CSharp/Strategies/TestStrategy.cs shows as example of creating a trendline in the call to onInit. Alos, a few account functions are logged using log4net This is just to prove the concept.

To implement a strategy, you just extend the Strategy class and implement the abstract methods.

I'll be adding trade functions to the strategy type shortly:
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

You will also be able to extend the base MQL type which will just contain the metatrader functionality, if you don't want to use the Strategy framework above.

I'm using log4net for C# logging, and SmartThreadPool for concurrency.

I also plan to provide a REST API at some stage. Possibly using https://github.com/scottoffen/Grapevine
The goals of this will be to control the MT4 terminal via REST and also to provide monitoring capabilities for custom strategies.
Also, a websockets implementation for event processing will be implemented.


## Installation Notes:
- Modify the build output path in MQL4CSharp properties in Visual Studio 2015 to match you metatrader terminal library directory (in mt4: file->open data folder)
- You need to copy log4net.dll. log4net.config and SmartThreadPool.dll to you metatrader root directory where the terminal.exe resides.
- Grab the mq4 file from https://github.com/jseparovic/MQL4CSharp/blob/master/MQL4CSharp/Mql/mql4csharp.mq4
- Grab the generated mqh files from https://github.com/jseparovic/MQL4CSharpGenerator/tree/master/out
- C# logging to file as per log4net.config
 

## Check out here for adding to this project:
https://github.com/jseparovic/MQL4CSharp/wiki/Adding-a-MQL4-Function-to-the-Framework

