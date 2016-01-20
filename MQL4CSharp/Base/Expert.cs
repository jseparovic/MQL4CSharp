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
        static SmartThreadPool smartThreadPool;

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

        [DllExport("ExecOnInit", CallingConvention = CallingConvention.StdCall)]
        public static void ExecOnInit([In, Out, MarshalAs(UnmanagedType.LPWStr)] string CSharpFullTypeName)
        {
            try
            {
                Type type = Type.GetType(CSharpFullTypeName);
                strategy = (Strategy)Activator.CreateInstance(type);

                smartThreadPool = new SmartThreadPool();
                smartThreadPool.MinThreads = 1;
                smartThreadPool.MaxThreads = 1;

                smartThreadPool.QueueWorkItem(OnInitThread);
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
                smartThreadPool.QueueWorkItem(OnDeinitThread);
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
                smartThreadPool.QueueWorkItem(OnTickThread);
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
                    smartThreadPool.QueueWorkItem(OnTimerThread);
                }
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }

    }
}