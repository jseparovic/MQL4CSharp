using Mql4CSharp.Base;
using Mql4CSharp.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mql4CSharp.Strategies
{
    class TestStrategy : Strategy
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
            ObjectCreate(0, "test", ObjectType.OBJ_TREND, 0, DateTime.Now.AddDays(-1), 1.09, DateTime.Now.AddDays(+1), 1.09);
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
