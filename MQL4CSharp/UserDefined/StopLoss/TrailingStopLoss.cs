using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.UserDefined.StopLoss
{
    class TrailingStopLoss
    {
        // Default Constructor
        int stopPips = 20; // step the stop pips
        int step = 5; // move every x pips

        public TrailingStopLoss(JStrategy strategy)
        {
            super(strategy);
        }

        public TrailingStopLoss(JStrategy strategy, int stopPips, int step)
        {
            super(strategy);
            this.stopPips = stopPips;
            this.step = step;
        }

        @Override
    public double getLevel(String symbol, Timeframe timeframe, int signal) throws Exception
        {
        return 0;
        }

        @Override
    public void manage(int ticket) throws ErrUnknownSymbol, ErrNoOrderSelected, Exception {
        // Select Open Trade
        strategy.orderSelect(ticket, SelectionType.SELECT_BY_TICKET, SelectionPool.MODE_TRADES);

        String symbol = strategy.orderSymbol();
        double orderOpenPrice = strategy.orderOpenPrice();
        double orderTakeProfit = strategy.orderTakeProfit();
        double orderStopLoss = strategy.orderStopLoss();
        int orderType = strategy.orderType();

        
        if(orderType == TradeOperation._OP_BUY) {
            double bid = strategy.marketInfo(symbol, MarketInfo.MODE_BID);
            if(bid > orderOpenPrice + stopPips* strategy.pipToPoint(symbol)) {
                double newStop = bid - stopPips * strategy.pipToPoint(symbol);
                if(orderStopLoss == 0 || orderStopLoss + step* strategy.pipToPoint(symbol) < newStop) {
                    strategy.orderModify(ticket, orderOpenPrice, newStop, orderTakeProfit, null, Color.Aqua.val);
                }
}
        }
        else if(orderType == TradeOperation._OP_SELL) {
            double ask = strategy.marketInfo(symbol, MarketInfo.MODE_ASK);
            //JStrategy.LOG.log(java.util.logging.Level.INFO, "ask: " + ask);
            //JStrategy.LOG.log(java.util.logging.Level.INFO, "orderOpenPrice - stopDistance * strategy.pipToPoint(symbol): " + (orderOpenPrice - stopDistance * strategy.pipToPoint(symbol)));
            if(ask<orderOpenPrice - stopPips* strategy.pipToPoint(symbol)) {
                double newStop = ask + stopPips * strategy.pipToPoint(symbol);
                //JStrategy.LOG.log(java.util.logging.Level.INFO, "newStop: " + newStop);
                //JStrategy.LOG.log(java.util.logging.Level.INFO, "newStop: " + newStop);
                if(orderStopLoss == 0 || orderStopLoss - step* strategy.pipToPoint(symbol) > newStop) {
                    strategy.orderModify(ticket, orderOpenPrice, newStop, orderTakeProfit, null, Color.Aqua.val);
                }
            }
        }
    
    }

    }
}
