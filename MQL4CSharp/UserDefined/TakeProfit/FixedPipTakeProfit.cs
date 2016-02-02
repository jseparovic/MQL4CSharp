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

using System;
using MQL4CSharp.Base;
using MQL4CSharp.Base.Common;
using MQL4CSharp.Base.Enums;

namespace MQL4CSharp.UserDefined.TakeProfit
{
    public class FixedPipTakeProfit : BaseTakeProfit
    {
        double pips;

        // Default Constructor
        public FixedPipTakeProfit(BaseStrategy strategy, double pips) : base(strategy)
        {
            this.pips = pips;
        }

        public override double getLevel(String symbol, TIMEFRAME timeframe, SignalResult signal)
        {
            double range = strategy.iHigh(symbol, (int)timeframe, 1) - strategy.iLow(symbol, (int)timeframe, 1);

            if (signal.getSignal() == (int)SignalResult.SELLMARKET)
            {
                return strategy.MarketInfo(symbol, (int)MARKET_INFO.MODE_BID) - pips* strategy.pipToPoint(symbol);
            }
            else
            {
                    return strategy.MarketInfo(symbol, (int)MARKET_INFO.MODE_ASK) + pips* strategy.pipToPoint(symbol);
            }
        }

        public override void manage(String symbol, TIMEFRAME timeframe)
        {
            // Do nothing
        }

    }
}
