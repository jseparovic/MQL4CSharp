using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Query.Dynamic;
using MQL4CSharp.Base.Enums;

namespace MQL4CSharp.UserDefined.Input
{
    public class CSVOrder
    {
        private String pair;
        String setup;
        String timeframe;
        double entry;
        double stop;
        double takeProfit1;
        double takeProfit2;

        double stopDistance;

        TRADE_OPERATION tradeOperation;

        public CSVOrder(string pair, string setup, string timeframe, double entry, double stop, double takeProfit1, double takeProfit2)
        {
            this.pair = pair;
            this.setup = setup;
            this.timeframe = timeframe;
            this.entry = entry;
            this.stop = stop;
            this.takeProfit1 = takeProfit1;
            this.takeProfit2 = takeProfit2;

            if (setup.ToLower().Contains("bullish"))
            {
                tradeOperation = TRADE_OPERATION.OP_BUYLIMIT;
                stopDistance = Convert.ToDouble(Convert.ToDecimal(entry) - Convert.ToDecimal(stop));
            }
            else if (setup.ToLower().Contains("bearish"))
            {
                tradeOperation = TRADE_OPERATION.OP_SELLLIMIT;
                stopDistance = Convert.ToDouble(Convert.ToDecimal(stop) - Convert.ToDecimal(entry));
            }
            else
            {
                throw new Exception("Could not parse setup: " + setup);
            }
        }

        public string Pair
        {
            get { return pair; }
            set { pair = value; }
        }

        public string Setup
        {
            get { return setup; }
            set { setup = value; }
        }

        public string Timeframe
        {
            get { return timeframe; }
            set { timeframe = value; }
        }

        public double Entry
        {
            get { return entry; }
            set { entry = value; }
        }

        public double Stop
        {
            get { return stop; }
            set { stop = value; }
        }

        public double TakeProfit1
        {
            get { return takeProfit1; }
            set { takeProfit1 = value; }
        }

        public double TakeProfit2
        {
            get { return takeProfit2; }
            set { takeProfit2 = value; }
        }

        public TRADE_OPERATION TradeOperation
        {
            get { return tradeOperation; }
            set { tradeOperation = value; }
        }

        public double StopDistance
        {
            get { return stopDistance; }
            set { stopDistance = value; }
        }
    }
}
