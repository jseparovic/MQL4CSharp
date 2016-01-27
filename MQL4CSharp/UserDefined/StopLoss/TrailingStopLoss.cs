using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQL4CSharp.Base;
using MQL4CSharp.Base.Common;
using MQL4CSharp.Base.Enums;

namespace MQL4CSharp.UserDefined.StopLoss
{
    public class TrailingStopLoss : BaseStopLoss
    {
        // Default Constructor
        int stopPips = 20; // step the stop pips
        int step = 5; // move every x pips

        public TrailingStopLoss(BaseStrategy strategy) : base(strategy)
        {
        }

        public TrailingStopLoss(BaseStrategy strategy, int stopPips, int step) : base(strategy)
        {
            this.stopPips = stopPips;
            this.step = step;
        }

        public override  double getLevel(String symbol, TIMEFRAME timeframe, int signal)
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
            int orderType = strategy.OrderType();

        
            if(orderType == (int)TRADE_OPERATION.OP_BUY)
            {
                double bid = strategy.MarketInfo(symbol, (int)MARKET_INFO.MODE_BID);
                if(bid > orderOpenPrice + stopPips* strategy.pipToPoint(symbol))
                {
                    double newStop = bid - stopPips * strategy.pipToPoint(symbol);
                    if(orderStopLoss == 0 || orderStopLoss + step* strategy.pipToPoint(symbol) < newStop)
                    {
                        strategy.OrderModify(ticket, orderOpenPrice, newStop, orderTakeProfit, new DateTime(), COLOR.Aqua);
                    }
                }
            }
            else if(orderType == (int)TRADE_OPERATION.OP_SELL)
            {
                double ask = strategy.MarketInfo(symbol, (int)MARKET_INFO.MODE_ASK);
                if(ask<orderOpenPrice - stopPips* strategy.pipToPoint(symbol))
                {
                    double newStop = ask + stopPips * strategy.pipToPoint(symbol);
                    if(orderStopLoss == 0 || orderStopLoss - step* strategy.pipToPoint(symbol) > newStop)
                    {
                        strategy.OrderModify(ticket, orderOpenPrice, newStop, orderTakeProfit, new DateTime(), COLOR.Aqua);
                    }
                }
            }
    
        }

    }
}
