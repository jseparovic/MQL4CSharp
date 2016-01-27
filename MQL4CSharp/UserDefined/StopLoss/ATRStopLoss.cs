using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.UserDefined.StopLoss
{
    public class ATRStopLoss : StopLoss
    {
        private final int atrPeriods;
        private final int atrShift;

        // Default Constructor
        public ATRStopLoss(JStrategy strategy, int atrPeriods, int atrShift)
        {
            super(strategy);
            this.atrPeriods = atrPeriods;
            this.atrShift = atrShift;
        }

        public double getLevel(String symbol, Timeframe timeframe, int signal) throws Exception
        {
        if (signal == Signal.SHORT)
        {
                return strategy.marketInfo(symbol, MarketInfo.MODE_BID) + strategy.iATR(symbol, timeframe, atrPeriods, atrShift);
            }
        else
        {
                return strategy.marketInfo(symbol, MarketInfo.MODE_ASK) - strategy.iATR(symbol, timeframe, atrPeriods, atrShift);
            }
        }

    public void manage(int ticket) throws ErrUnknownSymbol
        {
            // Do nothing
        }
    }
}
