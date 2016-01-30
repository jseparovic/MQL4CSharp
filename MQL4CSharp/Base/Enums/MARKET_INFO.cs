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

namespace MQL4CSharp.Base.Enums
{
    public enum MARKET_INFO
    {
        MODE_LOW	= 1, //	Low day price
        MODE_HIGH	= 2, //	High day price
        MODE_TIME   = 5, //	The last incoming tick time (last known server time)
        MODE_BID	= 9, //	Last incoming bid price. For the current symbol, it is stored in the predefined variable Bid
        MODE_ASK	= 10, //	Last incoming ask price. For the current symbol, it is stored in the predefined variable Ask
        MODE_POINT	= 11, //	Point size in the quote currency. For the current symbol, it is stored in the predefined variable Point
        MODE_DIGITS	= 12, //	Count of digits after decimal point in the symbol prices. For the current symbol, it is stored in the predefined variable Digits
        MODE_SPREAD	= 13, //	Spread value in points
        MODE_STOPLEVEL	= 14, //	Stop level in points
        MODE_LOTSIZE	= 15, //	A zero value of MODE_STOPLEVEL means either absence of any restrictions on the minimal distance for Stop Loss/Take Profit or the fact that a trade server utilizes some external mechanisms for dynamic level control, which cannot be translated in the client terminal. In the second case, GetLastError() can return error 130, because MODE_STOPLEVEL is actually "floating" here.
        MODE_TICKVALUE	= 16, //	Lot size in the base currency
        MODE_TICKSIZE	= 17, //	Tick value in the deposit currency
        MODE_SWAPLONG	= 18, //	Tick size in points
        MODE_SWAPSHORT	= 19, //	Swap of the buy order
        MODE_STARTING	= 20, //	Swap of the sell order
        MODE_EXPIRATION	= 21, //	Market starting date (usually used for futures)
        MODE_TRADEALLOWED	= 22, //	Market expiration date (usually used for futures)
        MODE_MINLOT	= 23, //	Trade is allowed for the symbol
        MODE_LOTSTEP	= 24, //	Minimum permitted amount of a lot
        MODE_MAXLOT	= 25, //	Step for changing lots
        MODE_SWAPTYPE	= 26, //	Maximum permitted amount of a lot
        MODE_PROFITCALCMODE	= 27, //	Swap calculation method. 0 - in points; 1 - in the symbol base currency; 2 - by interest; 3 - in the margin currency
        MODE_MARGINCALCMODE	= 28, //	Profit calculation mode. 0 - Forex; 1 - CFD; 2 - Futures
        MODE_MARGININIT	= 29, //	Margin calculation mode. 0 - Forex; 1 - CFD; 2 - Futures; 3 - CFD for indices
        MODE_MARGINMAINTENANCE	= 30, //	Initial margin requirements for 1 lot
        MODE_MARGINHEDGED	= 31, //	Margin to maintain open orders calculated for 1 lot
        MODE_MARGINREQUIRED	= 32, //	Hedged margin calculated for 1 lot
        MODE_FREEZELEVEL	= 33, //	Free margin required to open 1 lot for buying
    }
}
