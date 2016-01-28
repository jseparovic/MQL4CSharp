using MQL4CSharp.Base.Enums;
using System;

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
        public abstract double getLevel(String symbol, TIMEFRAME timeframe, int signal);

        // Method called onTick to manage the stop loss level
        public abstract void manage(int ticket);
    }
}
