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

namespace MQL4CSharp.UserDefined.StopLoss
{
    public class ATRStopLoss : BaseStopLoss
    {
        private int atrPeriods;
        private int atrShift;

        // Default Constructor
        public ATRStopLoss(BaseStrategy strategy, int atrPeriods, int atrShift) : base(strategy)
        {
            this.atrPeriods = atrPeriods;
            this.atrShift = atrShift;
        }

        public override double getLevel(String symbol, TIMEFRAME timeframe, int signal)
        {
            if (signal < 0)
            {
                return strategy.MarketInfo(symbol, (int)MARKET_INFO.MODE_BID) + strategy.iATR(symbol, (int)timeframe, atrPeriods, atrShift);
            }
            else
            {
                return strategy.MarketInfo(symbol, (int)MARKET_INFO.MODE_ASK) - strategy.iATR(symbol, (int)timeframe, atrPeriods, atrShift);
            }
        }

        public override void manage(int ticket)
        {
            // Do nothing
        }
    }
}
