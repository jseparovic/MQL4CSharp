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
using System.Collections.Generic;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.XPath;
using Amib.Threading;
using log4net;
using mqlsharp.Util;

namespace MQL4CSharp.Base.MQL
{
    public abstract class MQLExpert
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(MQLExpert));

        Int64 timerInterval = 1000;
        DateTime timer = DateTime.Now;
        SmartThreadPool threadPool;
        private string typeName;
        private int baseStrategyIx;

        private bool executingOnInit;
        private bool executingOnTick;
        private bool executingOnTimer;
        private bool executingOnDeinit;

        public Int64 ix;
        MQLCommandManager commandManager;

        public MQLExpert(Int64 ix) : base()
        {
            this.ix = ix;
            this.executingOnInit = true;
            this.executingOnTick = false;
            this.executingOnTimer = false;
            this.executingOnDeinit = false;
        }

        public MQLCommandManager getCommandManager()
        {
            return DLLObjectWrapper.getInstance().getMQLCommandManager(ix);
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RateInfo
        {
            public Int64 time;      // open date and time
            public Double open;     // Open price (absolute value)
            public Double high;     // Low price
            public Double low;      // High price
            public Double close;    // Close price
            public UInt64 volume;   // tick volume
            public Int32 spread;    // spread
            public UInt64 real;     // trade volume
        }

        unsafe RateInfo* rateInfo;

        int rateInfoSize;

        public void setTimerInterval(Int64 millis)
        {
            timerInterval = millis;
        }

        public static MQLExpert getInstance(Int64 ix)
        {
            return DLLObjectWrapper.getInstance().getMQLExpert(ix);
        }

        static void OnInitThread(Int64 index, string CSharpFullTypeName)
        {
            DLLObjectWrapper.getInstance().initMQLExpert(index, CSharpFullTypeName);
            try
            {
                getInstance(index).OnInit();
            }
            finally
            {
                getInstance(index).executingOnInit = false;
            }
        }

        static void OnDeinitThread(Int64 ix)
        {
            try
            {
                getInstance(ix).OnDeinit();
            }
            finally
            {
                getInstance(ix).executingOnDeinit = false;
            }
        }

        static void OnTickThread(Int64 ix)
        {
            try
            {
                getInstance(ix).OnTick();
            }
            finally
            {
                getInstance(ix).executingOnTick = false;
            }
        }

        static void OnTimerThread(Int64 ix)
        {
            try
            {
                getInstance(ix).OnTimer();
            }
            finally
            {
                getInstance(ix).executingOnTimer = false;
            }
        }

        private static SmartThreadPool getThreadPool(Int64 ix)
        {
            return DLLObjectWrapper.getInstance().getMQLThreadPool(ix);
        }

        [DllExport("SetRatesSize", CallingConvention = CallingConvention.StdCall)]
        public static void SetRatesSize(Int64 ix, int arr_size)
        {
            try
            {
                getInstance(ix).rateInfoSize = arr_size;
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }

        }

        int convIndex(int i)
        {
            return rateInfoSize - 1 - i;
        }

        public unsafe DateTime ITime(int i)
        {
            return DateUtil.FromUnixTime(rateInfo[convIndex(i)].time);
        }

        public unsafe double IOpen(int i)
        {
            return rateInfo[convIndex(i)].open;
        }

        public unsafe double IHigh(int i)
        {
            return rateInfo[convIndex(i)].high;
        }

        public unsafe double ILow(int i)
        {
            return rateInfo[convIndex(i)].low;
        }

        public unsafe double IVolume(int i)
        {
            return rateInfo[convIndex(i)].volume;
        }

        public unsafe double IClose(int i)
        {
            return rateInfo[convIndex(i)].close;
        }
        
        [DllExport("IsExecutingOnTick", CallingConvention = CallingConvention.StdCall)]
        public static bool IsExecutingOnTick(Int64 ix)
        {
            try
            {
                return getInstance(ix).executingOnTick;
            }
            catch (Exception e)
            {
                LOG.Error(e);
                return true;
            }
        }


        [DllExport("IsExecutingOnInit", CallingConvention = CallingConvention.StdCall)]
        public static bool IsExecutingOnInit(Int64 ix)
        {
            try
            {
                return getInstance(ix).executingOnInit;
            }
            catch (Exception e)
            {
                if (!e.Message.Equals("MQLExpert does not exist"))
                {
                    LOG.Error(e);
                }
                return true;
            }
        }

        [DllExport("IsExecutingOnTimer", CallingConvention = CallingConvention.StdCall)]
        public static bool IsExecutingOnTimer(Int64 ix)
        {
            try
            {
                return getInstance(ix).executingOnTimer;
            }
            catch (Exception e)
            {
                LOG.Error(e);
                return true;
            }
        }

        [DllExport("IsExecutingOnDeinit", CallingConvention = CallingConvention.StdCall)]
        public static bool IsExecutingOnDeinit(Int64 ix)
        {
            try
            {
                return getInstance(ix).executingOnDeinit;
            }
            catch (Exception e)
            {
                LOG.Error(e);
                return true;
            }
        }


        [DllExport("ExecOnInit", CallingConvention = CallingConvention.StdCall)]
        public static void ExecOnInit(Int64 ix, [MarshalAs(UnmanagedType.LPWStr)] string CSharpFullTypeName)
        {
            LOG.Debug(String.Format("Initializing: {0}", CSharpFullTypeName));
            DLLObjectWrapper.getInstance().initMQLThreadPool(ix);

            try
            {
                getThreadPool(ix).QueueWorkItem(OnInitThread, ix, CSharpFullTypeName);
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

        [DllExport("InitRates", CallingConvention = CallingConvention.StdCall)]
        public unsafe static void InitRates(Int64 ix, RateInfo* arr, int arr_size)
        {
            LOG.Info("Initializing Rates: " + ix);
            bool initialized = false;
            while (!initialized)
            {
                try
                {
                    getInstance(ix).rateInfo = arr;
                    getInstance(ix).rateInfoSize = arr_size;
                    initialized = true;
                }
                catch (Exception e)
                {
                    LOG.Error(e);
                }
            }
        }


        [DllExport("ExecOnDeinit", CallingConvention = CallingConvention.StdCall)]
        public static void ExecOnDeinit(Int64 ix)
        {
            getInstance(ix).executingOnDeinit = true;
            try
            {
                getThreadPool(ix).QueueWorkItem(OnDeinitThread, ix);
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }

        [DllExport("ExecOnTick", CallingConvention = CallingConvention.StdCall)]
        public static void ExecOnTick(Int64 ix)
        {
            getInstance(ix).executingOnTick = true;
            try
            {
                getThreadPool(ix).QueueWorkItem(OnTickThread, ix);
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }

        [DllExport("ExecOnTimer", CallingConvention = CallingConvention.StdCall)]
        public static void ExecOnTimer(Int64 ix)
        {
            getInstance(ix).executingOnTimer = true;
            try
            {
                DateTime now = DateTime.Now;
                if (now >= getInstance(ix).timer.AddMilliseconds(getInstance(ix).timerInterval)) // execute every timeout millis
                {
                    getInstance(ix).timer = now;
                    getThreadPool(ix).QueueWorkItem(OnTimerThread, ix);
                }
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }


        public abstract void OnInit();
        public abstract void OnDeinit();
        public abstract void OnTick();
        public abstract void OnTimer();

    }
}