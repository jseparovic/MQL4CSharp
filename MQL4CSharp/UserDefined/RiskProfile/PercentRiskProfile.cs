using MQL4CSharp.Base;
using MQL4CSharp.Base.Common;
using MQL4CSharp.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.UserDefined.RiskProfile
{
    public class PercentRiskProfile : BaseRiskProfile
    {

        private double cashAccountEquity;
        private double percentRisk;
        private double maxLots;
        private BaseStrategy strategy;

        public PercentRiskProfile(BaseStrategy strategy, double cashAccountEquity, double percentRisk, double maxLots) : base(strategy)
        {
            this.cashAccountEquity = cashAccountEquity;
            this.percentRisk = percentRisk;
            this.maxLots = maxLots;
            this.strategy = strategy;
        
        }

        public override double getLotSize(String symbol, double stopDistance)
        {

            double accountEquity = strategy.AccountEquity() + cashAccountEquity;
            double minLots = strategy.MarketInfo(symbol, (int)MarketInfo.MODE_MINLOT);
            double stopPips = stopDistance / strategy.MarketInfo(symbol, (int)MarketInfo.MODE_TICKSIZE);
            return Math.Min(maxLots, Math.Max(minLots, Math.Round(accountEquity* percentRisk / stopPips / 10, 2 )));
        }

    }

}
