using System;
using System.Text;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using log4net;
using mqlsharp.Util;

namespace MQL4CSharp.Base
{
    public class Rates
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(Rates));

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

        private static Rates rates;

        public static Rates getInstance()
        {
            if(rates == null)
            {
                rates = new Rates();
            }
            return rates;
        }


        public Rates getRates()
        {
            return rates;
        }

        unsafe RateInfo* rateInfo;

        int rateInfoSize;

        [DllExport("InitRates", CallingConvention = CallingConvention.StdCall)]
        unsafe public static void InitRates(RateInfo* arr, int arr_size)
        {
            try
            {
                getInstance().getRates().rateInfo = arr;
                getInstance().getRates().rateInfoSize = arr_size;
            }
            catch (Exception e)
            {
                LOG.Error(e);
            }
        }

        [DllExport("SetRatesSize", CallingConvention = CallingConvention.StdCall)]
        public static void SetRatesSize(int arr_size)
        {
            try
            {
                getInstance().getRates().rateInfoSize = arr_size;
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
    }
}