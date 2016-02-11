using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mqlsharp.Util;
using MQL4CSharp.Base.Common;
using MQL4CSharp.Base.Enums;
using MQL4CSharp.UserDefined.Input;
using MQL4CSharp.UserDefined.RiskProfile;

namespace MQL4CSharp.UserDefined.Strategy
{
    public class CSVOrderPlacer : Base.BaseStrategy
    {
        public CSVOrderPlacer(long ix) : base(ix)
        {
        }

        private int magicnumber = 3456;
        private int commissionPips = 1;

        private FixedDollarRiskProfile fixedDollarRiskProfile;

        public override void OnInit()
        {
            CSVOrders csvOrders = CSVOrders.getInstance();

            fixedDollarRiskProfile = new FixedDollarRiskProfile(this, 150, 10);

            foreach (var csvOrder in csvOrders)
            {
                LOG.InfoFormat("{0} on:{1} at:{2} stop:{3} tp1:{4} tp2:{5}", 
                    csvOrder.TradeOperation.ToString(), 
                    csvOrder.Pair, 
                    csvOrder.Entry,
                    csvOrder.Stop,
                    csvOrder.TakeProfit1,
                    csvOrder.TakeProfit2
                    );

                bool tradeExists = false;
                for (int i = 0; i < this.OrdersTotal(); i++)
                {
                    if (OrderSelect(i, (int)SELECTION_TYPE.SELECT_BY_POS, (int)SELECTION_POOL.MODE_TRADES) && OrderMagicNumber() == magicnumber && csvOrder.Pair == OrderSymbol())
                    {
                        if ((OrderType() == (int)TRADE_OPERATION.OP_SELL || OrderType() == (int)TRADE_OPERATION.OP_SELLLIMIT) 
                                && csvOrder.TradeOperation == TRADE_OPERATION.OP_SELLLIMIT)
                        {
                            tradeExists = true;
                            break;
                        }
                        if ((OrderType() == (int)TRADE_OPERATION.OP_BUY|| OrderType() == (int)TRADE_OPERATION.OP_BUYLIMIT)
                                && csvOrder.TradeOperation == TRADE_OPERATION.OP_BUYLIMIT)
                        {
                            tradeExists = true;
                            break;
                        }
                    }
                }

                if (!tradeExists)
                {
                    // Place the trade
                    LOG.InfoFormat("Placing trade on {0}", csvOrder.Pair);
                    executeTrade(csvOrder, true);
                    executeTrade(csvOrder, false);
                }

            }

        }


        private void executeTrade(CSVOrder csvOrder, bool tp1)
        {
            string symbol = csvOrder.Pair;
            int cmd = (int)csvOrder.TradeOperation;
            double volume = fixedDollarRiskProfile.getLotSize(csvOrder.Pair, csvOrder.StopDistance);
            double price = (double)csvOrder.Entry;
            int slippage = 3;
            double stoploss = (double)csvOrder.Stop;
            double takeprofit = (double)csvOrder.TakeProfit1;
            string comment = csvOrder.Setup;
            DateTime expiration = DateUtil.FromUnixTime(0);

            if (!tp1)
            {
                takeprofit = (double)csvOrder.TakeProfit2;
            }

            OrderSend(symbol, cmd, volume, price, slippage, stoploss, takeprofit, comment, magicnumber, expiration, COLOR.AliceBlue);
        }


        public override void OnDeinit()
        {
        }

        public override void init()
        {
            throw new NotImplementedException();
        }

        public override void destroy()
        {
        }

        public override SignalResult evaluate(string symbol)
        {
            throw new NotImplementedException();
        }

        public override double getStopLoss(string symbol, SignalResult signal)
        {
            throw new NotImplementedException();
        }

        public override double getTakeProfit(string symbol, SignalResult signal)
        {
            throw new NotImplementedException();
        }

        public override double getEntryPrice(string symbol, SignalResult signal)
        {
            throw new NotImplementedException();
        }

        public override DateTime getExpiry(string symbol, SignalResult signal)
        {
            throw new NotImplementedException();
        }

        public override double getLotSize(string symbol, double stopDistance)
        {
            throw new NotImplementedException();
        }

        public override int getMagicNumber(string symbol)
        {
            throw new NotImplementedException();
        }

        public override string getComment(string symbol)
        {
            throw new NotImplementedException();
        }

        public override bool isAsleep(string symbol)
        {
            throw new NotImplementedException();
        }

        public override bool filter(string symbol)
        {
            throw new NotImplementedException();
        }

        public override void onNewDate(string symbol, TIMEFRAME timeframe)
        {
            throw new NotImplementedException();
        }

        public override void onNewCandle(string symbol, TIMEFRAME timeframe)
        {
            throw new NotImplementedException();
        }

        public override void manageOpenTrades(string symbol, int ticket)
        {
            throw new NotImplementedException();
        }

        public override void OnTick()
        {
        }

        public override void OnTimer()
        {
        }
    }
}
