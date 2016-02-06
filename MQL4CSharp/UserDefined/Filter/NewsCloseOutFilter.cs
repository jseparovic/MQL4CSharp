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
using System;
using System.Web.Caching;
using mqlsharp.Util;
using MQL4CSharp.Base.Enums;
using MQL4CSharp.UserDefined.Input;
using NodaTime;

namespace MQL4CSharp.UserDefined.Filter
{
    public class NewsCloseOutFilter : BaseFilter
    {
        private BaseStrategy strategy;
        private NewsReports newsReports;

        public NewsCloseOutFilter(BaseStrategy strategy, NewsReports newsReports) : base(strategy)
        {
            this.strategy = strategy;
            this.newsReports = newsReports;
        }

        public override bool filter(String symbol, TIMEFRAME timeframe)
        {
            DateTime currentMarketTime = DateUtil.FromUnixTime((long)strategy.MarketInfo(symbol, (int)MARKET_INFO.MODE_TIME));

            foreach (NewsReport newsReport in newsReports)
            {
                if (symbol.Contains(newsReport.getCurrency())
                    && currentMarketTime > newsReport.getCloseOutPrior()
                    && currentMarketTime < newsReport.getDateTime())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
