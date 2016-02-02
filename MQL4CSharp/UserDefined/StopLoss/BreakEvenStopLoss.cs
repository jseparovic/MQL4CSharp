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
using MQL4CSharp.Base.Enums;

namespace MQL4CSharp.UserDefined.StopLoss
{
    public class BreakEvenStopLoss : BaseStopLoss
    {
        int stopPips = 20; // minimum break even stop distance from price
        decimal commisionPips = new decimal(0.8);

        public BreakEvenStopLoss(BaseStrategy strategy) : base(strategy)
        {
        }

        public BreakEvenStopLoss(BaseStrategy strategy, int stopPips, decimal commisionPips) : base(strategy)
        {
            this.stopPips = stopPips;
            this.commisionPips = commisionPips;
        }

        public override double getLevel(String symbol, TIMEFRAME timeframe, int signal)
        {
            return 0;
        }

        public override void manage(String symbol, int ticket)
        {
            // Select Open Trade
            strategy.OrderSelect(ticket, (int)SELECTION_TYPE.SELECT_BY_TICKET, (int)SELECTION_POOL.MODE_TRADES);

            decimal orderStopLoss = (decimal) strategy.OrderStopLoss();
            decimal orderOpenPrice = (decimal) strategy.OrderOpenPrice();
            int orderType = strategy.OrderType();
            decimal newStop;

            if (orderType == (int)TRADE_OPERATION.OP_BUY)
            {
                newStop = orderOpenPrice + commisionPips* (decimal)strategy.pipToPoint(symbol);
                if (newStop != orderStopLoss)
                {
                    decimal bid = (decimal) strategy.MarketInfo(symbol, (int)MARKET_INFO.MODE_BID);
                    if (bid > newStop + stopPips* (decimal)strategy.pipToPoint(symbol))
                    {
                        strategy.OrderModify(ticket, (double)orderOpenPrice, (double)newStop, strategy.OrderTakeProfit(), strategy.OrderExpiration(), 0);
                    }
                }
            }
            else if (orderType == (int)TRADE_OPERATION.OP_SELL)
            {
                newStop = orderOpenPrice - commisionPips* (decimal)strategy.pipToPoint(symbol);
                if (newStop != orderStopLoss)
                {
                    decimal ask = (decimal) strategy.MarketInfo(symbol, (int)MARKET_INFO.MODE_ASK);
                    if (ask<newStop - stopPips* (decimal)strategy.pipToPoint(symbol))
                    {
                        strategy.OrderModify(ticket, (double)orderOpenPrice, (double)newStop, strategy.OrderTakeProfit(), strategy.OrderExpiration(), 0);
                    }
                }
            }

        }

    }
}
