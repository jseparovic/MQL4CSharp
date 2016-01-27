using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mqlsharp.Util;
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
