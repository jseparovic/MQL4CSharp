using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.Base.Enums
{
    public enum ENUM_APPLIED_PRICE
    {
        PRICE_CLOSE	= 0, //	Close price
        PRICE_OPEN = 1, // Open price
        PRICE_HIGH = 2, // The maximum price for the period
        PRICE_LOW = 3, // The minimum price for the period
        PRICE_MEDIAN = 4, // Median price, (high + low)/2
        PRICE_TYPICAL = 5, // Typical price, (high + low + close)/3
        PRICE_WEIGHTED = 6, // Weighted close price, (high + low + close + close)/4

    }
}
