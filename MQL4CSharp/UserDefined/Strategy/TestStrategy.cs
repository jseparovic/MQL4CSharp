﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQL4CSharp.Base;
using MQL4CSharp.Base.Enums;

namespace MQL4CSharp.UserDefined.Strategy
{
    class TestStrategy : Base.BaseStrategy
    {
        public TestStrategy() : base()
        {
            setTimerInterval(1000);
        }

        public override void OnDeinit()
        {

        }

        public override void OnInit()
        {
            LOG.Info("AccountBalance: " + AccountBalance());
            LOG.Info("AccountCompany: " + AccountCompany());
            LOG.Info("AccountEquity: " + AccountEquity());
            LOG.Info("AccountFreeMargin: " + AccountFreeMargin());
            LOG.Info("AccountName: " + AccountName());
            LOG.Info("AccountNumber: " + AccountNumber());
            ObjectCreate(ChartID(), "test", ENUM_OBJECT.OBJ_TREND, 0, DateTime.Now.AddDays(-1), 1.0860, DateTime.Now.AddDays(+1), 1.086);
        }

        public override void OnTick()
        {
            LOG.Debug("OnTick: " + IClose(0));
        }

        public override void OnTimer()
        {
            //LOG.Debug("OnTimer:" + IClose(0));
        }
    }
}