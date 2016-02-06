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

        public override string ToString()
        {
            return "candleDistanceToDayStart=" + candleDistanceToDayStart + ", " +
                   "currentLocalDate=" + currentLocalDate + ", " +
                   "currentCandleDateTime=" + currentCandleDateTime + ", " +
                   "signalStartDateTime=" + signalStartDateTime + ", " +
                   "signalStopDateTime=" + signalStopDateTime;
        }
    }
}
