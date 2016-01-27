using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.UserDefined.StopLoss
{
    class SRStopLoss
    {
        public static int pipTolerance = 5;
        // Default Constructor
        public SR(JStrategy strategy)
        {
            super(strategy);
        }

        @Override
    public double getLevel(String symbol, Timeframe timeframe, int signal) throws Exception
        {
        if (signal == Signal.SHORT) {
                double current_high = strategy.iHigh(symbol, timeframe, 0);
                for (int i = 1; strategy.iHigh(symbol, timeframe, i) > current_high; i++)
                {
                    current_high = strategy.iHigh(symbol, timeframe, i);
                }
                return current_high + pipTolerance * strategy.pipToPoint(symbol);
            } else {
                double current_low = strategy.iLow(symbol, timeframe, 0);
                for (int i = 1; strategy.iLow(symbol, timeframe, i) < current_low; i++)
                {
                    current_low = strategy.iLow(symbol, timeframe, i);
                }
                return current_low - pipTolerance * strategy.pipToPoint(symbol);
            }
        }

        @Override
    public void manage(int ticket) throws ErrUnknownSymbol
        {
            // Do nothing
        }
    }
}
