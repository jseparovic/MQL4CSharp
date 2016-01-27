using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.Base.Common
{
    public abstract class BaseSignal
    {
        public BaseStrategy strategy;
        bool evalOncePerCandle = true;
        LocalTime signalStart = LocalTime.Midnight;
        LocalTime signalStop = LocalTime.Midnight;

        public BaseSignal(BaseStrategy strategy)
        {
            this.strategy = strategy;
        }

        /**
         *
         * param strategy
         * param evalOncePerCandle : set true when signal doesn't change on current bar
         * param signalStart : signal start time
         * param signalStop : signal stop time (LocalTime.MIDNIGHT will mean next day)
         */
        public BaseSignal(BaseStrategy strategy, bool evalOncePerCandle, LocalTime signalStart, LocalTime signalStop) : this(strategy)
        {
            this.evalOncePerCandle = evalOncePerCandle;
            this.signalStart = signalStart;
            this.signalStop = signalStop;
        }

        int startDayShift = 0;
        Map<Pair<String, Timeframe>, Date> dayStart;        // midnight of current day
        Map<Pair<String, Timeframe>, Date> currentCandle;

        public Signal evaluate(String symbol, Timeframe timeframe) throws Exception
        {
            Date currentMarketTime = strategy.marketInfo_MODE_TIME(symbol);
            //        Date newStartDay = signalStart;

            LocalDateTime localDateTime;


        // if new day, update:
        if(!newStartDay.equals(dayStart))
        {
                LOG.info("New Day Detected: " + newStartDay);
                dayStart = newStartDay;
                startTrading = DateUtil.getDateFromCurrentAnd24HRTime(currentMarketTime, timeStart);
            }

            // new candle detected
            Date newCurrentCandle = strategy.iTime(symbol, timeframe, 0);
        if(!newCurrentCandle.equals(currentCandle))
        {
                LOG.info("New Candle Detected: " + newCurrentCandle);
                currentCandle = newCurrentCandle;

                // Get distance to first candle of the day
                Date iTime = null;
                for (int i = 0; iTime == null || (iTime != null && iTime.after(startDay)); i++)
                {
                    iTime = strategy.iTime(symbol, timeframe, i);
                    startDayShift = i;
                }

                LOG.info("Current candle distance from day start: " + startDayShift);
            }

            // Get the days high/low:
            daysHigh = strategy.iHigh(symbol, Timeframe.PERIOD_D1, 0);
            daysLow = strategy.iLow(symbol, Timeframe.PERIOD_D1, 0);


        return new Signal();
    }

    public Signal evaluate(String symbol, Timeframe timeframe) throws Exception
    {
        return evaluate(symbol, timeframe, true);
    }

}
}
