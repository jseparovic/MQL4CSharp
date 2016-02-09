using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Grapevine;
using Grapevine.Server;
using log4net;
using log4net.Config;
using MQL4CSharp.Base.Enums;
using MQL4CSharp.Base.MQL;
using Newtonsoft.Json.Linq;

namespace MQL4CSharp.Base.REST
{

    public sealed class MQLRESTResource : RESTResource
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(MQLRESTResource));

        int DEFAULT_CHART_ID = 0;

        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/[0-9]+/accountbalance$")]
        public void HandleAccountBalance(HttpListenerContext context)
        {
            long chartid = Int64.Parse(context.Request.Url.Segments[1].Replace("/", ""));
            this.SendJsonResponse(context, AccountBalance(chartid));
        }

        [RESTRoute(Method = HttpMethod.GET, PathInfo = @"^/accountbalance$")]
        public void HandleAccountBalance0(HttpListenerContext context)
        {
            this.SendJsonResponse(context, AccountBalance(DEFAULT_CHART_ID));
        }

        private JObject AccountBalance(long chartId)
        {
            MQLCommandManager mqlCommandManager = DLLObjectWrapper.getInstance().getMQLCommandManager(chartId);
            int id = mqlCommandManager.ExecCommand(MQLCommand.AccountBalance_1, new List<object>());
            while (mqlCommandManager.IsCommandRunning(id)) ; // block while command is running

            JObject jObject = new JObject();
            jObject["result"] = Convert.ToDecimal(mqlCommandManager.GetCommandResult(id));
            return jObject;
        }
    }
}
