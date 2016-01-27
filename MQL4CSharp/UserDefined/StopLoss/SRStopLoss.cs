using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public override double getLevel(String symbol, TIMEFRAME timeframe, int signal)
        {
            if (signal == SignalResult.SELLMARKET)
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

        public override void manage(int ticket)
        {
            // Do nothing
        }
    }
}
