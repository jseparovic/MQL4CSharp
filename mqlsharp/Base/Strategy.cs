using log4net;
using Mql4CSharp.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using mqlsharp.Util;

namespace Mql4CSharp.Base
{
    public abstract class Strategy
    {
        public ILog LOG;

        public Strategy()
        {
            LOG = LogManager.GetLogger(GetType());
        }

        public void setTimerInterval(Int64 intervalMillis)
        {
            Expert.setTimerInterval(intervalMillis);    
        }

        public abstract void OnInit();
        public abstract void OnDeinit();
        public abstract void OnTick();
        public abstract void OnTimer();

        public unsafe DateTime ITime(int i)
        {
            return Rates.getInstance().ITime(i);
        }

        public unsafe double IOpen(int i)
        {
            return Rates.getInstance().IOpen(i);
        }

        public unsafe double IHigh(int i)
        {
            return Rates.getInstance().IHigh(i);
        }

        public unsafe double ILow(int i)
        {
            return Rates.getInstance().ILow(i);
        }

        public unsafe double IVolume(int i)
        {
            return Rates.getInstance().IVolume(i);
        }

        public unsafe double IClose(int i)
        {
            return Rates.getInstance().IClose(i);
        }



        /// <summary>
        /// The function creates an object with the specified name, type, and the initial coordinates in the specified chart subwindow of the specified chart.
        /// </summary>
        /// <param name="object_name">object name</param>
        /// <param name="object_type">object type</param>
        /// <param name="time1">time of the first anchor point</param>
        /// <param name="price1">price of the first anchor point</param>
        /// <param name="time2">time of the second anchor point</param>
        /// <param name="price2">price of the second anchor point</param>
        public bool ObjectCreate(   String object_name,
                                    ObjectType object_type,
                                    DateTime time1,
                                    Double price1,
                                    DateTime time2,
                                    Double price2)
        {
            return CallObjectCreate(0, object_name, object_type, 0, time1, price1, time2, price2);
        }


        /// <summary>
        /// The function creates an object with the specified name, type, and the initial coordinates in the specified chart subwindow of the specified chart.
        /// </summary>
        /// <param name="object_name">object name</param>
        /// <param name="object_type">object type</param>
        /// <param name="time1">time of the first anchor point</param>
        /// <param name="price1">price of the first anchor point</param>
        /// <param name="time2">time of the second anchor point</param>
        /// <param name="price2">price of the second anchor point</param>
        public bool ObjectCreate(   String object_name,
                                    ObjectType object_type,
                                    DateTime time1,
                                    Double price1,
                                    DateTime time2,
                                    Double price2,
                                    DateTime time3,
                                    Double price3)
        {
            return CallObjectCreate(0, object_name, object_type, 0, time1, price1, time2, price2);
        }

        /// <summary>
        /// The function creates an object with the specified name, type, and the initial coordinates in the specified chart subwindow of the specified chart.
        /// </summary>
        /// <param name="chart_id">chart ID</param>
        /// <param name="object_name">object name</param>
        /// <param name="object_type">object type</param>
        /// <param name="sub_window">window index</param>
        /// <param name="time1">time of the first anchor point</param>
        /// <param name="price1">price of the first anchor point</param>
        /// <param name="time2">time of the second anchor point</param>
        /// <param name="price2">price of the second anchor point</param>
        public bool ObjectCreate(   Int64 chart_id,
                                    String object_name,
                                    ObjectType object_type,
                                    Int32 sub_window,
                                    DateTime time1,
                                    Double price1,
                                    DateTime time2,
                                    Double price2)
        {
            return CallObjectCreate(0, object_name, object_type, 0, time1, price1, time2, price2);
        }


        /// <summary>
        /// The function creates an object with the specified name, type, and the initial coordinates in the specified chart subwindow.
        /// </summary>
        /// <param name="chart_id">chart ID</param>
        /// <param name="object_name">object name</param>
        /// <param name="object_type">object type</param>
        /// <param name="sub_window">window index</param>
        /// <param name="time1">time of the first anchor point</param>
        /// <param name="price1">price of the first anchor point</param>
        /// <param name="time2">time of the second anchor point</param>
        /// <param name="price2">price of the second anchor point</param>
        /// <param name="time3">time of the third anchor point</param>
        /// <param name="price3">price of the third anchor point</param>
        public bool ObjectCreate(   Int64 chart_id,
                                    String object_name,
                                    ObjectType object_type,
                                    Int32 sub_window,
                                    DateTime time1,
                                    Double price1,
                                    DateTime time2,
                                    Double price2,
                                    DateTime time3,
                                    Double price3)
        {
            return CallObjectCreate(0, object_name, object_type, 0, time1, price1, time2, price2, time3, price3);
        }

        /// <summary>
        /// The function creates an object with the specified name, type, and the initial coordinates in the specified chart subwindow.
        /// </summary>
        /// <param name="chart_id">chart ID</param>
        /// <param name="object_name">object name</param>
        /// <param name="object_type">object type</param>
        /// <param name="sub_window">window index</param>
        /// <param name="time1">time of the first anchor point</param>
        /// <param name="price1">price of the first anchor point</param>
        /// <param name="time2">time of the second anchor point</param>
        /// <param name="price2">price of the second anchor point</param>
        /// <param name="time3">time of the third anchor point</param>
        /// <param name="price3">price of the third anchor point</param>
        private bool CallObjectCreate( Int64 chart_id,
                                       String object_name,
                                       ObjectType object_type,
                                       Int32 sub_window,
                                       DateTime time1,
                                       Double price1,
                                       DateTime time2,
                                       Double price2,
                                       DateTime time3=default(DateTime),
                                       Double price3=0)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(object_name);
            parameters.Add(object_type);
            parameters.Add(sub_window);
            parameters.Add(DateUtil.ToMT4TimeString(time1));
            parameters.Add(price1);
            parameters.Add(DateUtil.ToMT4TimeString(time2));
            parameters.Add(price2);
            if (time3 != default(DateTime))
            {
                parameters.Add(DateUtil.ToMT4TimeString(time3));
                parameters.Add(price3);
            }

            CommandManager.getInstance().ExecCommand(Command.objectCreate1, parameters);
            while (CommandManager.getInstance().IsCommandRunning()) Thread.Sleep(1);

            return (bool) CommandManager.getInstance().GetCommandResult();
        }



    }
}
