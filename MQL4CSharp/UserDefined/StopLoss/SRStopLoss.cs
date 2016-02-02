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
    public class SRStopLoss : BaseStopLoss
    {
        public static int pipTolerance = 5;

        // Default Constructor
        public SRStopLoss(BaseStrategy strategy) : base (strategy)
        {
        }

        public override double getLevel(String symbol, TIMEFRAME timeframe, SignalResult signal)
        {
            if (signal.getSignal() == SignalResult.SELLMARKET)
            {
                double current_high = strategy.iHigh(symbol, (int)timeframe, 0);
                for (int i = 1; strategy.iHigh(symbol, (int)timeframe, i) > current_high; i++)
                {
                    current_high = strategy.iHigh(symbol, (int)timeframe, i);
                }
                return current_high + pipTolerance * strategy.pipToPoint(symbol);
            }
            else
            {
                double current_low = strategy.iLow(symbol, (int)timeframe, 0);
                for (int i = 1; strategy.iLow(symbol, (int)timeframe, i) < current_low; i++)
                {
                    current_low = strategy.iLow(symbol, (int)timeframe, i);
                }
                return current_low - pipTolerance * strategy.pipToPoint(symbol);
            }
        }

        public override void manage(String symbol, int ticket)
        {
            // Do nothing
        }
    }
}
