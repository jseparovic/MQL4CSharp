/*
Copyright 2016 Jason Separovic

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using log4net;
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