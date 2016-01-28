using System;
using MQL4CSharp.Base.Common;
using MQL4CSharp.Base.Enums;
using MQL4CSharp.UserDefined.Filter;
using MQL4CSharp.UserDefined.RiskProfile;
using MQL4CSharp.UserDefined.Signal;
using MQL4CSharp.UserDefined.StopLoss;
using MQL4CSharp.UserDefined.TakeProfit;

namespace MQL4CSharp.UserDefined.Strategy
{
    public class MaCrossStrategy : Base.BaseStrategy
    {
        private int MAGIC_NUMBER = 1111;

        private String COMMENT = "TestStrategy";

        private BaseStopLoss srStopLoss;
        private BaseTakeProfit fixedPipTakeProfit;
        private BaseRiskProfile percentRiskProfile;
        private BaseStopLoss breakEvenStopLoss;
        private BaseFilter timeOfDayFilter;
        private BaseSignal maCross;
        private TIMEFRAME strategyTimeframe = TIMEFRAME.PERIOD_M15;

        public MaCrossStrategy() : base()
        {
            srStopLoss = new SRStopLoss(this);
            fixedPipTakeProfit = new FixedPipTakeProfit(this, 40);
            percentRiskProfile = new PercentRiskProfile(this, 0, 0.02, 5);
            breakEvenStopLoss = new BreakEvenStopLoss(this, 20, 1);
            timeOfDayFilter = new TimeOfDayFilter(this, "09:00", "23:00");
            maCross = new MACross(this);
        }

        public override void init()
        {
            LOG.Info("AccountBalance: " + AccountBalance());
            LOG.Info("AccountCompany: " + AccountCompany());
            LOG.Info("AccountEquity: " + AccountEquity());
            LOG.Info("AccountFreeMargin: " + AccountFreeMargin());
            LOG.Info("AccountName: " + AccountName());
            LOG.Info("AccountNumber: " + AccountNumber());
            ObjectCreate(ChartID(), "test", ENUM_OBJECT.OBJ_TREND, 0, DateTime.Now.AddDays(-1), 1.0860, DateTime.Now.AddDays(+1), 1.086);
        }

        public override void destroy()
        {
            
        }

        // returns true if ok to take a trade
        public override bool filter(string symbol)
        {
            //return true;
            return timeOfDayFilter.filter(symbol, strategyTimeframe);
        }

        // returns signal direction or neutral
        public override int evaluate(string symbol)
        {
            //return SignalResult.newBUYMARKET().getSignal();
            return maCross.evaluate(symbol, strategyTimeframe).getSignal();
        }

        public override double getStopLoss(string symbol, int signal)
        {
            return srStopLoss.getLevel(symbol, strategyTimeframe, signal);
        }

        public override double getTakeProfit(string symbol, int signal)
        {
            return fixedPipTakeProfit.getLevel(symbol, strategyTimeframe, signal);
        }

        public override double getLotSize(string symbol, double stopDistance)
        {
            return percentRiskProfile.getLotSize(symbol, stopDistance);
        }

        public override int getMagicNumber(string symbol)
        {
            return MAGIC_NUMBER;
        }

        public override string getComment(string symbol)
        {
            return COMMENT;
        }

        public override bool isAsleep(string symbol)
        {
            return false;
        }

        public override void manageOpenTrades(string symbol)
        {
            breakEvenStopLoss.manage(OrderTicket());
        }


    }
}
