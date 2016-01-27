using MQL4CSharp.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.Base.Common
{
    public abstract class BaseFilter
    {
        private BaseFilter strategy;

        public BaseFilter(BaseFilter strategy)
        {
            this.strategy = strategy;
        }

        public abstract bool filter(String symbol, Timeframe timeframe);
    }
}
