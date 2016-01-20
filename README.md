# MQL4CSharp
CSharp Library for Metatrader 4

This library is not complete, however it demonstrates a framework for calling MQL4 commands from within a C# class.

Basically, the CommandManager will handle one command at a time and will only ever be called from the Base Strategy which is in it's own thread.
The "command" should set the ID, and parameters, then MQL4 will detect a command ready to be called (it is currently checking every millisecond in OnTimer), then it will parse it, execute it, and set the result.
The original command called from the custom strategy in C# will then be returned once it detects a result has been set.

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
  
