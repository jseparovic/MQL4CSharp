using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amib.Threading;
using log4net;

namespace MQL4CSharp.Base.MQL
{
    public class MQLThreadPool : SmartThreadPool
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(MQLThreadPool));

        private Int64 ix;
        public MQLThreadPool(Int64 index)
        {
            this.ix = index;
            LOG.Debug(String.Format("Initializing ThreadPool: {0}", index));
            MinThreads = 1;
            MaxThreads = 1;
        }
    }
}
