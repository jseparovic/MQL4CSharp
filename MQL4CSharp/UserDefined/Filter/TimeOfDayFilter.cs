using MQL4CSharp.Base;
using MQL4CSharp.Base.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.UserDefined.Filter
{
    public class TimeOfDayFilter : BaseFilter
    {
        private String timeStart;
        private String timeStop;
        int lookBack;

        /**
         *
         * @param strategy
         * @param timeStart : eg "07:30"
         * @param timeStop : eg "14:00"
         */
        public TimeOfDayFilter(BaseStrategy strategy, String timeStart, String timeStop) : base(strategy)
        {
            this.lookBack = lookBack;
            this.timeStart = timeStart;
            this.timeStop = timeStop;
        }

        public override bool filter(String symbol, Timeframe timeframe)
        {
            Date currentMarketTime = strategy.marketInfo_MODE_TIME(symbol);
            Date startTrading = DateUtil.getDateFromCurrentAnd24HRTime(currentMarketTime, timeStart);
            Date stopTrading = DateUtil.getDateFromCurrentAnd24HRTime(currentMarketTime, timeStop);

        // Trade Window
        if (currentMarketTime.after(startTrading) && currentMarketTime.before(stopTrading))
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
