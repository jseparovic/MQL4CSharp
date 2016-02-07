using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQL4CSharp.UserDefined.Strategy
{
    /// <summary>
    /// Attach this one to your chart just to enable the REST API.
    /// It does nothing, but every MQLExpert has a REST endpoint
    /// </summary>
    public class MQLRESTStrategy : Base.MQLBase
    {
        public MQLRESTStrategy(long ix) : base(ix)
        {
        }

        public override void OnInit()
        {
        }

        public override void OnDeinit()
        {
        }

        public override void OnTick()
        {
        }

        public override void OnTimer()
        {
        }
    }
}
