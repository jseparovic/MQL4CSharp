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
    public class FixedDollarRiskProfile : BaseRiskProfile
    {

        private double dollarRisk;
        private double maxLots;
        private BaseStrategy strategy;

        public FixedDollarRiskProfile(BaseStrategy strategy, double dollarRisk, double maxLots) : base(strategy)
        {
            this.dollarRisk = dollarRisk;
            this.maxLots = maxLots;
            this.strategy = strategy;
        
        }

        public override double getLotSize(String symbol, double stopDistance)
        {
            double minLots = strategy.MarketInfo(symbol, (int)MARKET_INFO.MODE_MINLOT);
            double stopPips = stopDistance/strategy.pipToPoint(symbol);
            double tickvalue = strategy.MarketInfo(symbol, (int)MARKET_INFO.MODE_TICKVALUE);
            double calcLotSize = Math.Round((dollarRisk/tickvalue) / stopPips/10, 2);
            return Math.Min(maxLots, Math.Max(minLots, calcLotSize));
        }

    }

}
