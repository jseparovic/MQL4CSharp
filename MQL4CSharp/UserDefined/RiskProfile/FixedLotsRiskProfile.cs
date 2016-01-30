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
