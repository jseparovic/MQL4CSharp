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

using MQL4CSharp.Base;
using MQL4CSharp.Base.Common;
using MQL4CSharp.Base.Enums;
using System;

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
            double minLots = strategy.MarketInfo(symbol, (int)MARKET_INFO.MODE_MINLOT);
            double stopPips = stopDistance/strategy.pipToPoint(symbol);
            double calcLotSize = Math.Round(accountEquity*percentRisk/stopPips/10, 2);
            //strategy.LOG.Debug("getLotSize stopDistance: " + stopDistance);
            //strategy.LOG.Debug("getLotSize accountEquity: " + accountEquity);
            //strategy.LOG.Debug("getLotSize minLots: " + minLots);
            //strategy.LOG.Debug("getLotSize stopPips: " + stopPips);
            //strategy.LOG.Debug("getLotSize calcLotSize: " + calcLotSize);
            return Math.Min(maxLots, Math.Max(minLots, calcLotSize));
        }

    }

}
