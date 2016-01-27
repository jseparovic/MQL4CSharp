using MQL4CSharp.Base;
using MQL4CSharp.Base.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mqlsharp.Util;
using MQL4CSharp.Base.Enums;
using NodaTime;

namespace MQL4CSharp.UserDefined.Filter
{
    public class TimeOfDayFilter : BaseFilter
    {
        private String timeStart;
        private String timeStop;
        private BaseStrategy strategy;

        /**
         *
         * @param strategy
         * @param timeStart : eg "07:30"
         * @param timeStop : eg "14:00"
         */

        public TimeOfDayFilter(BaseStrategy strategy, String timeStart, String timeStop) : base(strategy)
        {
            this.strategy = strategy;
            this.timeStart = timeStart;
            this.timeStop = timeStop;
        }

        public override bool filter(String symbol, TIMEFRAME timeframe)
        {
            DateTime currentMarketTime = DateUtil.FromUnixTime((long) strategy.MarketInfo(symbol, (int) MARKET_INFO.MODE_TIME));
            DateTime startTrading = DateUtil.getDateFromCurrentAnd24HRTime(currentMarketTime, timeStart);
            DateTime stopTrading = DateUtil.getDateFromCurrentAnd24HRTime(currentMarketTime, timeStop);

            // Trade Window
            if (currentMarketTime > startTrading && currentMarketTime < stopTrading)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
