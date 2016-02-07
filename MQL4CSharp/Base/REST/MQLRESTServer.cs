using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grapevine.Server;

namespace MQL4CSharp.Base.REST
{
    public class MQLRESTServer : RESTServer
    {
        private static String host = "192.168.1.9";
        private static String port = "80";
        private static String protocol = "http";
        private static String index = "index.html";
        private static String webroot = "/api";
        private static int maxThreads = 8;

        public MQLRESTServer() : base(host, port, protocol, index, webroot, maxThreads)
        {
            Start();
        }
    }
}
