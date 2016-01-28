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

        public override double getLevel(String symbol, TIMEFRAME timeframe, int signal)
        {
            double range = strategy.iHigh(symbol, (int)timeframe, 1) - strategy.iLow(symbol, (int)timeframe, 1);

            if (signal == (int)SignalResult.SELLMARKET)
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
