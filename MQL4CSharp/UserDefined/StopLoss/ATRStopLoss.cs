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
