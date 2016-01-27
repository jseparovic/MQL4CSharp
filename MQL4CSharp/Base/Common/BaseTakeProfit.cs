using MQL4CSharp.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.Base.Common
{
    public abstract class BaseTakeProfit
    {
        public BaseStrategy strategy;

        public BaseTakeProfit(BaseStrategy strategy)
        {
            this.strategy = strategy;
        }

        // Method to return the Take Profit Level
        public abstract double getLevel(String symbol, Timeframe timeframe, int signal);

        // Method called onTick to manage the Take Profit Level
        public abstract void manage(String symbol, Timeframe timeframe);
    }
}
