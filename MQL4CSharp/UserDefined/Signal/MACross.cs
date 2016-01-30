using MQL4CSharp.Base;
using MQL4CSharp.Base.Common;
using MQL4CSharp.Base.Enums;

namespace MQL4CSharp.UserDefined.Signal
{
    public class MACross : BaseSignal
    {
        private int maPeriodFast = 3;
        private int maPeriodSlow = 14;
        private ENUM_MA_METHOD methodFast = ENUM_MA_METHOD.MODE_SMA;
        private ENUM_MA_METHOD methodSlow = ENUM_MA_METHOD.MODE_EMA;
        private int maShift = 0;

        public MACross(BaseStrategy strategy) : base(strategy)
        {

        }

        public MACross(BaseStrategy strategy, int maPeriodFast, int maPeriodSlow, ENUM_MA_METHOD methodFast, ENUM_MA_METHOD methodSlow, int maShift) : this(strategy)
        {
            this.maPeriodFast = maPeriodFast;
            this.maPeriodSlow = maPeriodSlow;
            this.methodFast = methodFast;
            this.methodSlow = methodSlow;
            this.maShift = maShift;
        }

        public override SignalResult evaluate(string symbol, TIMEFRAME timeframe)
        {
            double maFast1 = strategy.iMA(symbol, (int)timeframe, maPeriodFast, maShift, (int)methodFast, (int)ENUM_APPLIED_PRICE.PRICE_CLOSE, 1);
            double maFast2 = strategy.iMA(symbol, (int)timeframe, maPeriodFast, maShift, (int)methodFast, (int)ENUM_APPLIED_PRICE.PRICE_CLOSE, 2);
            double maSlow1 = strategy.iMA(symbol, (int)timeframe, maPeriodSlow, maShift, (int)methodSlow, (int)ENUM_APPLIED_PRICE.PRICE_CLOSE, 1);
            double maSlow2 = strategy.iMA(symbol, (int)timeframe, maPeriodSlow, maShift, (int)methodSlow, (int)ENUM_APPLIED_PRICE.PRICE_CLOSE, 2);

            if (maFast1 < maSlow1 && maFast2 > maSlow2)
            {
                return SignalResult.newSELLMARKET();
            }
            else if (maFast1 > maSlow1 && maFast2 < maSlow2)
            {
                return SignalResult.newBUYMARKET();
            }
            else
            {
                return SignalResult.newNEUTRAL();
            }
        }
    }
}
