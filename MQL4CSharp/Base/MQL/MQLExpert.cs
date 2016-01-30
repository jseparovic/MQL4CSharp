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

        static BaseStrategy strategy;
        static Int64 timerInterval = 1000;
        static DateTime timer = DateTime.Now;
        static SmartThreadPool threadPool;

        public static void setTimerInterval(Int64 millis)
        {
            timerInterval = millis;
        }

        public static void OnInitThread()
        {
            strategy.OnInit();
        }

        public static void OnDeinitThread()
        {
            strategy.OnDeinit();
        }

        public static void OnTickThread()
        {
            strategy.OnTick();
        }

        public static void OnTimerThread()
        {
            strategy.OnTimer();
        }

        private static SmartThreadPool getThreadPool()
        {
            if (threadPool == null)
            {
                threadPool = new SmartThreadPool();
                threadPool.MinThreads = 1;
                threadPool.MaxThreads = 1;
            }
            return threadPool;
        }

        [DllExport("ExecOnInit", CallingConvention = CallingConvention.StdCall)]
        public static void ExecOnInit([In, Out, MarshalAs(UnmanagedType.LPWStr)] string CSharpFullTypeName)
        {
            try
            {
                Type type = Type.GetType(CSharpFullTypeName);
                strategy = (BaseStrategy)Activator.CreateInstance(type);

                getThreadPool().QueueWorkItem(OnInitThread);
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
                getThreadPool().QueueWorkItem(OnDeinitThread);
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }

        [DllExport("ExecOnTick", CallingConvention = CallingConvention.StdCall)]
        public static void ExecOnTick()
        {
            try
            {
                getThreadPool().QueueWorkItem(OnTickThread);
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
                if (now >= timer.AddMilliseconds(timerInterval)) // execute every timeout millis
                {
                    timer = now;
                    getThreadPool().QueueWorkItem(OnTimerThread);
                }
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }

    }
}