# MQL4CSharp
##C# Library for Metatrader 4

This library is currently a work in progress. 
It demonstrates a framework for calling MQL4 commands from within a C# class.

When a command from a C# Strategy is called, it sets a flag which the MQL expert is polling every millisecond within it's onTimer() function. As the C# Strategy code is called in it's own thread, it will not block the MQL code, and the MQL function can execute while the C# function waits for the result. When the MQL expert detects a command waiting, parses it, executes it and sets the result and error code. The C# base strategy polls for the result every millisecond, so as soon as the result is set by MQL, the C# function will then return with the result.

In initial tests, 1 millisecond polling does not show any performance impacts to the system. 1000 bool tests every second for a 4GHz CPU isn't much theoretically. So performance here should be pretty much the same as running the code directly in MQL. This will be configurable.

The basic workflow => https://i.imgur.com/8yvFxz1.png

I mainly started this project as a way to get decent backtesting performance in MT4 whilst using a mainstream language. I picked C# due to simplicity.

https://github.com/jseparovic/MQL4CSharp/blob/master/MQL4CSharp/UserDefined/Strategy/MaCrossStrategy.cs shows as example strategy using the framework.

To implement a strategy, you just extend the Strategy class and implement the abstract methods.

Methods like:
  - getStopLoss
  - getTakeProfit
  - getEntryPrice
  - getExpiry
  - getLotSize
  - getComment
  - getMagicNumber
  - manageOpenTrades
  
Also, abstract type should be extended for specific logic to keep things somewhat separate and reusable:
  - BaseSignal
  - BaseStopLoss
  - BaseTakeProfit
  - BaseFilter
  - BaseRiskProfile

You can also just extend the base MQL type which just contains the metatrader functionality, if you don't want to use the Strategy framework above.

I'm using log4net for C# logging, and SmartThreadPool for concurrency.

I also plan to provide a REST API at some stage. Possibly using https://github.com/scottoffen/Grapevine
The goals of this will be to control the MT4 terminal via REST and also to provide monitoring capabilities for custom strategies.
Also, a websockets implementation for event processing will be implemented.


## Installation Notes:
- Modify the build output path in MQL4CSharp properties in Visual Studio 2015 to match you metatrader terminal library directory (in mt4: file->open data folder)
- You need to copy log4net.dll. log4net.config SmartThreadPool.dll NodaTime.dll and NodaTime.xml to you metatrader root directory where the terminal.exe resides.
- Grab the mq4 file from https://github.com/jseparovic/MQL4CSharp/blob/master/MQL4CSharp/Mql/mql4csharp.mq4
- Grab the generated mqh files from https://github.com/jseparovic/MQL4CSharpGenerator/tree/master/out and put them in your mql/include dir
- C# logging to file as per log4net.config
 
- If you just want to use the library or extend the BaseStrategy type: Nuget it: https://www.nuget.org/packages/MQL4CSharp/
```
PM> Install-Package MQL4CSharp
```

### Some Backtesting notes
Backtesting now works by executing commands in the onTick() method (as well as onTimer()) as onTimer is not supported in Strategy Tester. The onTick method in MQL will now continue to process commands until it detects the IsExecutingOnTick() to be false, so that all commands are run within the same tick.
This could probably do with some further optimisation.


## Design Notes:

I've put together a rough class diagram here. https://i.imgur.com/V2l2lQZ.png
It shows what I plan to do to provide a REST api into MQL and Custom Strategies.
I've found that debugging is impossible with the latest Metatrader (just crashes as soon as you attach), so I've decided that providing a REST interface and ability to JSONify data within the system, should help with debugging purposes. Also, it will be pretty neat to be able to write some JS fountend using this API.


