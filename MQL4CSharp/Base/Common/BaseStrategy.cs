using log4net;
using System;
using mqlsharp.Util;
using MQL4CSharp.Base.Common;
using MQL4CSharp.Base.Enums;
using MQL4CSharp.Base.MQL;

namespace MQL4CSharp.Base
{
    public abstract class BaseStrategy : MQLBase
    {
        public ILog LOG;

        public BaseStrategy()
        {
            LOG = LogManager.GetLogger(GetType());
        }

        public BaseStrategy(String strategyName) : base()
        {
            LOG.Info("Running Strategy: " + strategyName);
        }

        public override void OnTick()
        {
            String symbol = Symbol();

            this.manageOpenTrades(symbol);

            if (this.isAsleep(symbol))
            {
                return;
            }

            if (!this.filter(symbol))
            {
                return;
            }

            // Check for a signal
            int signal = this.evaluate(symbol);
            if (signal != 0)
            {
                this.executeTrade(symbol, signal);
            }
        }

        public double pipToPoint(String symbol)
        {
            if (MarketInfo(symbol, (int)MARKET_INFO.MODE_DIGITS) == 3 || MarketInfo(symbol, (int)MARKET_INFO.MODE_DIGITS) == 5)
            {
                return 10 * MarketInfo(symbol, (int)MARKET_INFO.MODE_TICKSIZE);
            }
            else
            {
                return MarketInfo(symbol, (int)MARKET_INFO.MODE_TICKSIZE);
            }
        }


        // Method to execute the trade
        public void executeTrade(String symbol, int signal)
        {
            TRADE_OPERATION op;
            double price, lots;
            int slippage = 5;
            double stoploss = this.getStopLoss(symbol, signal);
            double takeprofit = this.getTakeProfit(symbol, signal);
            String comment = this.getComment(symbol);
            int magic = this.getMagicNumber(symbol);
            DateTime expiration = new DateTime();
            COLOR arrowColor = COLOR.Aqua;

            double stopDistance;

            DateTime lastBuyOpen, lastSellOpen;
            bool openBuyOrder = false, openSellOrder = false, openBuyStopOrder = false, openSellStopOrder = false;

            if (signal == SignalResult.BUYMARKET)
            {
                op = TRADE_OPERATION.OP_BUY;
                price = MarketInfo(symbol, (int)MARKET_INFO.MODE_ASK);
            }
            else if (signal == SignalResult.SELLMARKET)
            {
                op = TRADE_OPERATION.OP_SELL;
                price = MarketInfo(symbol, (int)MARKET_INFO.MODE_BID);
            }
            else if (signal == SignalResult.BUYSTOP)
            {
                op = TRADE_OPERATION.OP_BUYSTOP;
                price = getStopEntry(symbol, signal);
            }
            else if (signal == SignalResult.SELLSTOP)
            {
                op = TRADE_OPERATION.OP_SELLSTOP;
                price = getStopEntry(symbol, signal);
            }
            else
            {
                throw new Exception("Invalid Signal signal=" + signal);
            }

            if (signal > 0)
            {
                stopDistance = price - stoploss;
            }
            else
            {
                stopDistance = stoploss - price;
            }

            //LOG.Debug("stopDistance: " + stopDistance);
            //LOG.Debug("price: " + price);
            //LOG.Debug("stoploss: " + stoploss);
            //LOG.Debug("takeprofit: " + takeprofit);

            // Calculate lots
            lots = this.getLotSize(symbol, stopDistance);

            // Check open trades on this symbol
            for (int i = 0; i < OrdersTotal(); i++)
            {
                OrderSelect(i, (int)SELECTION_TYPE.SELECT_BY_POS, (int)SELECTION_POOL.MODE_TRADES);
                if (OrderType() == (int)TRADE_OPERATION.OP_BUY && OrderSymbol().Equals(symbol) && OrderMagicNumber() == magic)
                {
                    lastBuyOpen = OrderOpenTime();
                    openBuyOrder = true;
                }
                else if (OrderType() == (int)TRADE_OPERATION.OP_SELL && OrderSymbol().Equals(symbol) && OrderMagicNumber() == magic)
                {
                    lastSellOpen = OrderOpenTime();
                    openSellOrder = true;
                }
                else if (OrderType() == (int)TRADE_OPERATION.OP_BUYSTOP && OrderSymbol().Equals(symbol) && OrderMagicNumber() == magic)
                {
                    openBuyStopOrder = true;
                }
                else if (OrderType() == (int)TRADE_OPERATION.OP_SELLSTOP && OrderSymbol().Equals(symbol) && OrderMagicNumber() == magic)
                {
                    openSellStopOrder = true;
                }
            }

            if ((signal == SignalResult.BUYMARKET && !openBuyOrder) || (signal == SignalResult.SELLMARKET && !openSellOrder) 
                    || (signal == SignalResult.BUYSTOP && !openBuyStopOrder) || (signal == SignalResult.SELLSTOP && !openSellStopOrder))
            {
                LOG.Info(String.Format("Executing Trade on {0} at {1}", new Object[] { symbol, DateUtil.FromUnixTime((long)MarketInfo(symbol, (int)MARKET_INFO.MODE_TIME)) }));
                RefreshRates();
                if (signal == SignalResult.BUYMARKET)
                {
                    price = MarketInfo(symbol, (int)MARKET_INFO.MODE_ASK);
                }
                else if (signal == SignalResult.SELLMARKET)
                {
                    price = MarketInfo(symbol, (int)MARKET_INFO.MODE_BID);
                }

                int ticket = OrderSend(symbol, (int)op, lots, price, slippage, stoploss, takeprofit, comment, magic, expiration, arrowColor);
                int err = GetLastError();
            }
        }

        public override void OnTimer()
        {

        }

        public override void OnInit()
        {
            init();
        }

        public override void OnDeinit()
        {
            destroy();
        }

        public abstract void init();

        public abstract void destroy();

        // Abstract method to evaluate the current tick and check whether or not a signal exists
        public abstract int evaluate(String symbol);

        public abstract double getStopLoss(String symbol, int signal);

        public abstract double getTakeProfit(String symbol, int signal);

        public abstract double getLotSize(String symbol, double stopDistance);

        public abstract int getMagicNumber(String symbol);

        public abstract String getComment(String symbol);

        public abstract bool isAsleep(String symbol);

        public abstract bool filter(String symbol);


        // Non Abstract methods
        public double getStopEntry(String symbol, int signal)
        {
            return 0;
        }

        // Method to manage the trade
        public abstract void manageOpenTrades(String symbol);

    }
}