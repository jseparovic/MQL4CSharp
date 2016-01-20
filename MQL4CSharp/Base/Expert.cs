using System;
using System.Text;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Threading;
using Amib.Threading;
using log4net;

namespace MQL4CSharp.Base
{
    public class Expert
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(Expert));

        static Strategy strategy;
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
                strategy = (Strategy)Activator.CreateInstance(type);

                getThreadPool().QueueWorkItem(OnInitThread);
            }
            catch (ArgumentNullException e)
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