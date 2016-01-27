using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.Base.Common
{
    public abstract class BaseRiskProfile
    {
        private BaseStrategy strategy;

        public BaseRiskProfile(BaseStrategy strategy)
        {
            this.strategy = strategy;
        }

        public abstract double getLotSize(String symbol, double stopDistance);
    }
}
