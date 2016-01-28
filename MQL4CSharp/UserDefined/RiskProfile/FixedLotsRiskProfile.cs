using System;
using MQL4CSharp.Base;
using MQL4CSharp.Base.Common;

namespace MQL4CSharp.UserDefined.RiskProfile
{
    public class FixedLotsRiskProfile : BaseRiskProfile
    {
        double lots;

        public FixedLotsRiskProfile(BaseStrategy strategy, double lots) : base(strategy)
        {
            this.lots = lots;
        }

        public override double getLotSize(String symbol, double stopDistance)
        {
            return lots;
        }

    }
}
