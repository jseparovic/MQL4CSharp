using System;
using MQL4CSharp.Base;
using MQL4CSharp.Base.Common;
using MQL4CSharp.Base.Enums;

namespace MQL4CSharp.UserDefined.StopLoss
{
    public class BreakEvenStopLoss : BaseStopLoss
    {
        int stopPips = 20; // minimum break even stop distance from price
        double commisionPips = 0.8;

        public BreakEvenStopLoss(BaseStrategy strategy) : base(strategy)
        {
        }

        public BreakEvenStopLoss(BaseStrategy strategy, int stopPips, double commisionPips) : base(strategy)
        {
            this.stopPips = stopPips;
            this.commisionPips = commisionPips;
        }

        public override double getLevel(String symbol, TIMEFRAME timeframe, int signal)
        {
            return 0;
        }

        public override void manage(int ticket)
        {
            // Select Open Trade
            strategy.OrderSelect(ticket, (int)SELECTION_TYPE.SELECT_BY_TICKET, (int)SELECTION_POOL.MODE_TRADES);

            String symbol = strategy.OrderSymbol();
            double orderOpenPrice = strategy.OrderOpenPrice();
            double orderTakeProfit = strategy.OrderTakeProfit();
            double orderStopLoss = strategy.OrderStopLoss();
            DateTime orderExpiration = strategy.OrderExpiration();
            int orderType = strategy.OrderType();
            double newStop;

            if (orderType == (int)TRADE_OPERATION.OP_BUY)
            {
                newStop = orderOpenPrice + commisionPips* strategy.pipToPoint(symbol);
                if (newStop != orderStopLoss)
                {
                    double bid = strategy.MarketInfo(symbol, (int)MARKET_INFO.MODE_BID);
                    if (bid > newStop + stopPips* strategy.pipToPoint(symbol))
                    {
                        strategy.OrderModify(ticket, orderOpenPrice, newStop, orderTakeProfit, orderExpiration, 0);
                    }
                }
            }
            else if (orderType == (int)TRADE_OPERATION.OP_SELL)
            {
                newStop = orderOpenPrice - commisionPips* strategy.pipToPoint(symbol);
                if (newStop != orderStopLoss)
                {
                    double ask = strategy.MarketInfo(symbol, (int)MARKET_INFO.MODE_ASK);
                    if (ask<newStop - stopPips* strategy.pipToPoint(symbol))
                    {
                        strategy.OrderModify(ticket, orderOpenPrice, newStop, orderTakeProfit, orderExpiration, 0);
                    }
                }
            }

        }

    }
}
