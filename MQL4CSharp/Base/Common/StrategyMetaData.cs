using System;
using NodaTime;

namespace MQL4CSharp.Base.Common
{
    public class StrategyMetaData
    {

        int candleDistanceToDayStart = 0;
        LocalDate currentLocalDate;
        DateTime currentCandleDateTime;
        DateTime signalStartDateTime;
        DateTime signalStopDateTime;

        public StrategyMetaData()
        {
        }

        public int getCandleDistanceToDayStart()
        {
            return candleDistanceToDayStart;
        }

        public void setCandleDistanceToDayStart(int candleDistanceToDayStart)
        {
            this.candleDistanceToDayStart = candleDistanceToDayStart;
        }

        public LocalDate getCurrentLocalDate()
        {
            return currentLocalDate;
        }

        public void setCurrentLocalDate(LocalDate currentLocalDate)
        {
            this.currentLocalDate = currentLocalDate;
        }

        public DateTime getCurrentCandleDateTime()
        {
            return currentCandleDateTime;
        }

        public void setCurrentCandleDateTime(DateTime currentCandleDateTime)
        {
            this.currentCandleDateTime = currentCandleDateTime;
        }

        public DateTime getSignalStartDateTime()
        {
            return signalStartDateTime;
        }

        public void setSignalStartDateTime(DateTime signalStartDateTime)
        {
            this.signalStartDateTime = signalStartDateTime;
        }

        public DateTime getSignalStopDateTime()
        {
            return signalStopDateTime;
        }

        public void setSignalStopDateTime(DateTime signalStopDateTime)
        {
            this.signalStopDateTime = signalStopDateTime;
        }
    }
}
