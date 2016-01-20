using System;
using System.Text;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using log4net;
using log4net.Config;
using System.Reflection;
using System.IO;

namespace mql4csharp
{
    public class Logging
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(Logging));

        public static object TraceExtension { get; private set; }

        [DllExport("InitLogging", CallingConvention = CallingConvention.StdCall)]
        public static void InitLogging()
        {
            try
            {
                if (!log4net.LogManager.GetRepository().Configured)
                {
                    string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    var configFile = new FileInfo(assemblyFolder + "\\log4net.config");

                    if (!configFile.Exists)
                    {
                        throw new FileLoadException(String.Format("The configuration file {0} does not exist", configFile));
                    }

                    log4net.Config.XmlConfigurator.Configure(configFile);
                }
                LOG.Info("Logging initialized");
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }
    }
}