using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using mqlsharp.Util;
using MQL4CSharp.Base.Enums;

namespace MQL4CSharp.Base
{
    public abstract class Strategy : MQL
    {
        public ILog LOG;

        public Strategy()
        {
            LOG = LogManager.GetLogger(GetType());
        }
    
    }
}