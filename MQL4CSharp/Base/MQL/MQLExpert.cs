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
using Amib.Threading;
using log4net;

namespace MQL4CSharp.Base.MQL
{
    public class MQLExpert
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(MQLExpert));

        BaseStrategy strategy;
        Int64 timerInterval = 1000;
        DateTime timer = DateTime.Now;
        SmartThreadPool threadPool;
        private string typeName;
        private bool executingOnTick = false;

        private static MQLExpert mqlExpert;

        public static MQLExpert getInstance()
        {
            if (mqlExpert == null)
            {
                mqlExpert = new MQLExpert();
            }
            return mqlExpert;
        }

        private MQLExpert()
        {

        }

        public void setTimerInterval(Int64 millis)
        {
            timerInterval = millis;
        }

        static void OnInitThread()
        {
            Type type = Type.GetType(getInstance().typeName);
            getInstance().strategy = (BaseStrategy)Activator.CreateInstance(type);
            getInstance().strategy.OnInit();
        }

        static void OnDeinitThread()
        {
            getInstance().strategy.OnDeinit();
            getInstance().strategy = null;
        }

        static void OnTickThread()
        {
            getInstance().strategy.OnTick();
            getInstance().executingOnTick = false;
        }

        static void OnTimerThread()
        {
            getInstance().strategy.OnTimer();
        }

        private SmartThreadPool getThreadPool()
        {
            if (threadPool == null)
            {
                LOG.Debug(String.Format("Initializing ThreadPool"));
                getInstance().threadPool = new SmartThreadPool();
                getInstance().threadPool.MinThreads = 1;
                getInstance().threadPool.MaxThreads = 1;
            }
            return getInstance().threadPool;
        }


        [DllExport("IsExecutingOnTick", CallingConvention = CallingConvention.StdCall)]
        public static bool IsExecutingOnTick()
        {
            try
            {
                return getInstance().executingOnTick;
            }
            catch (Exception e)
            {
                LOG.Error(e);
                return true;
            }
        }

        [DllExport("ExecOnInit", CallingConvention = CallingConvention.StdCall)]
        public static void ExecOnInit([MarshalAs(UnmanagedType.LPWStr)] string CSharpFullTypeName)
        {
            LOG.Debug(String.Format("Initializing: {0}", CSharpFullTypeName));
            getInstance().typeName = CSharpFullTypeName;
            try
            {
                getInstance().getThreadPool().QueueWorkItem(OnInitThread);
            }
            catch (ArgumentNullException)
            {
                LOG.Error(String.Format("Strategy Class {0} not found", CSharpFullTypeName));
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }

        [DllExport("ExecOnDeinit", CallingConvention = CallingConvention.StdCall)]
        public static void ExecOnDeinit()
        {
            try
            {
                getInstance().getThreadPool().QueueWorkItem(OnDeinitThread);
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }

        [DllExport("ExecOnTick", CallingConvention = CallingConvention.StdCall)]
        public static void ExecOnTick()
        {
            getInstance().executingOnTick = true;
            try
            {
                getInstance().getThreadPool().QueueWorkItem(OnTickThread);
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }

        [DllExport("ExecOnTimer", CallingConvention = CallingConvention.StdCall)]
        public static void ExecOnTimer()
        {
            try
            {
                DateTime now = DateTime.Now;
                if (now >= getInstance().timer.AddMilliseconds(getInstance().timerInterval)) // execute every timeout millis
                {
                    getInstance().timer = now;
                    getInstance().getThreadPool().QueueWorkItem(OnTimerThread);
                }
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }

    }
}