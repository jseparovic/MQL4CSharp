using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.Base.Enums
{
    public enum Timeframe
    {
        PERIOD_CURRENT = 0,
        PERIOD_M1 = 1,
        PERIOD_M5 = 5,
        PERIOD_M15 = 15,
        PERIOD_M30 = 30,
        PERIOD_H1 = 60,
        PERIOD_H4 = 240,
        PERIOD_D1 = 1440,
        PERIOD_W1 = 10080,
        PERIOD_MN1 = 43200
    }
}
