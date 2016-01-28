using MQL4CSharp.Base.Enums;
using System;

namespace MQL4CSharp.Base.Common
{
    public abstract class BaseFilter
    {
        private BaseStrategy strategy;

        public BaseFilter(BaseStrategy strategy)
        {
            this.strategy = strategy;
        }

        public abstract bool filter(String symbol, TIMEFRAME timeframe);
    }
}
