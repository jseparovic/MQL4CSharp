using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.Base.Enums
{
    public enum TRADE_OPERATION
    {
        OP_BUY = 0, // Buy operation
        OP_SELL = 1, // Sell operation
        OP_BUYLIMIT = 2,  //Buy limit pending order
        OP_SELLLIMIT = 3, // Sell limit pending order
        OP_BUYSTOP = 4, // Buy stop pending order
        OP_SELLSTOP = 5, // Sell stop pending order
    }
}
