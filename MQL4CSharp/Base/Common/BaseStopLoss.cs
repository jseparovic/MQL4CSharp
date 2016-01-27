using MQL4CSharp.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.Base.Common
{
    public abstract class BaseStopLoss
    {
        public BaseStrategy strategy;

        public BaseStopLoss(BaseStrategy strategy)
        {
            this.strategy = strategy;
        }

        // Method to return the stop loss level
        public abstract double getLevel(String symbol, Timeframe timeframe, int signal);

        // Method called onTick to manage the stop loss level
        public abstract void manage(int ticket);
    }
}
