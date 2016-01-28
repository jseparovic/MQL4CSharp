using System;
using MQL4CSharp.Base.Enums;

namespace MQL4CSharp.Base.Common
{
    public abstract class BaseSignal
    {
        public BaseStrategy strategy;

        public BaseSignal(BaseStrategy strategy)
        {
            this.strategy = strategy;
        }

        public abstract SignalResult evaluate(String symbol, TIMEFRAME timeframe);

    }

}
