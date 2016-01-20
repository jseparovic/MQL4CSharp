using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using mqlsharp.Util;
using MQL4CSharp.Base.Enums;

namespace MQL4CSharp.Base
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

        /// <summary>
        /// ITime from the RatesInfo Structure, this is for the current chart symbol and timeframe
        /// </summary>
        /// <param name="i">Shift</param>
        /// <returns>DateTime</returns>
        public unsafe DateTime ITime(int i)
        {
            return Rates.getInstance().ITime(i);
        }

        /// <summary>
        /// IOpen from the RatesInfo Structure, this is for the current chart symbol and timeframe
        /// </summary>
        /// <param name="i">Shift</param>
        /// <returns>double</returns>
        public unsafe double IOpen(int i)
        {
            return Rates.getInstance().IOpen(i);
        }

        /// <summary>
        /// IHigh from the RatesInfo Structure, this is for the current chart symbol and timeframe
        /// </summary>
        /// <param name="i">Shift</param>
        /// <returns>double</returns>
        public unsafe double IHigh(int i)
        {
            return Rates.getInstance().IHigh(i);
        }

        /// <summary>
        /// ILow from the RatesInfo Structure, this is for the current chart symbol and timeframe
        /// </summary>
        /// <param name="i">Shift</param>
        /// <returns>double</returns>
        public unsafe double ILow(int i)
        {
            return Rates.getInstance().ILow(i);
        }

        /// <summary>
        /// IVolume from the RatesInfo Structure, this is for the current chart symbol and timeframe
        /// </summary>
        /// <param name="i">Shift</param>
        /// <returns>double</returns>
        public unsafe double IVolume(int i)
        {
            return Rates.getInstance().IVolume(i);
        }

        /// <summary>
        /// IClose from the RatesInfo Structure, this is for the current chart symbol and timeframe
        /// </summary>
        /// <param name="i">Shift</param>
        /// <returns>double</returns>
        public unsafe double IClose(int i)
        {
            return Rates.getInstance().IClose(i);
        }



        ////
        /// Order Functions
        /// 








        ////
        /// Object Functions
        /// 

        /// <summary>
        /// The function creates an object with the specified name, type, and the initial coordinates in the specified chart subwindow of the specified chart.
        /// </summary>
        /// <param name="object_name">object name</param>
        /// <param name="object_type">object type</param>
        /// <param name="time1">time of the first anchor point</param>
        /// <param name="price1">price of the first anchor point</param>
        /// <param name="time2">time of the second anchor point</param>
        /// <param name="price2">price of the second anchor point</param>
        public bool ObjectCreate(
            String object_name,
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
        public bool ObjectCreate(
            String object_name,
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
        public bool ObjectCreate(
            Int64 chart_id,
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
        public bool ObjectCreate(
            Int64 chart_id,
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

        private bool CallObjectCreate(
            Int64 chart_id,
            String object_name,
            ObjectType object_type,
            Int32 sub_window,
            DateTime time1,
            Double price1,
            DateTime time2,
            Double price2,
            DateTime time3 = default(DateTime),
            Double price3 = 0)
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

            CommandManager.getInstance().ExecCommand(Command.ObjectCreate, parameters);
            while (CommandManager.getInstance().IsCommandRunning()) Thread.Sleep(1);
            return (bool) CommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Removes all objects from the specified chart, specified chart subwindow, of the specified type.    
        /// </summary>
        /// <param name="chart_id">Chart identifier</param>
        /// <param name="sub_window">Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than WindowsTotal().</param>
        /// <param name="object_type">Type of the object. The value can be one of the values of the ENUM_OBJECT enumeration. EMPTY (-1) means all types.</param>
        /// <returns>Returns the number of deleted objects.</returns>
        public int ObjectsDeleteAll(
            Int64 chart_id,
            Int32 sub_window = -1,
            Int32 object_type = -1)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(sub_window);
            parameters.Add(object_type);

            CommandManager.getInstance().ExecCommand(Command.ObjectsDeleteAll1, parameters);
            while (CommandManager.getInstance().IsCommandRunning()) Thread.Sleep(1);
            return (int) CommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Removes all objects of the specified type from the specified chart subwindow.
        /// </summary>
        /// <param name="sub_window">Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than WindowsTotal().</param>
        /// <param name="object_type">Type of the object. The value can be one of the values of the ENUM_OBJECT enumeration. EMPTY (-1) means all types.</param>
        /// <returns>Returns the number of deleted objects.</returns>
        public int ObjectsDeleteAll(
            Int32 sub_window = -1,
            Int32 object_type = -1)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(sub_window);
            parameters.Add(object_type);

            CommandManager.getInstance().ExecCommand(Command.ObjectsDeleteAll2, parameters);
            while (CommandManager.getInstance().IsCommandRunning()) Thread.Sleep(1);
            return (int) CommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Removes all objects of the specified type using prefix in object names.
        /// </summary>
        /// <param name="chart_id">Chart identifier</param>
        /// <param name="prefix"> Prefix in object names. All objects whose names start with this set of characters will be removed from chart. You can specify prefix as 'name' or 'name*'  both variants will work the same. If an empty string is specified as the prefix, objects with all possible names will be removed.</param>
        /// <param name="sub_window">Number of the chart window. Must be greater or equal to -1 (-1 mean all subwindows, 0 means the main chart window) and less than WindowsTotal().</param>
        /// <param name="object_type">Type of the object. The value can be one of the values of the ENUM_OBJECT enumeration. EMPTY (-1) means all types.</param>
        /// <returns>Returns the number of deleted objects.</returns>
        public int ObjectsDeleteAll(
            Int64 chart_id,
            string prefix,
            Int32 sub_window = -1,
            Int32 object_type = -1)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(prefix);
            parameters.Add(sub_window);
            parameters.Add(object_type);

            CommandManager.getInstance().ExecCommand(Command.ObjectsDeleteAll3, parameters);
            while (CommandManager.getInstance().IsCommandRunning()) Thread.Sleep(1);
            return (int)CommandManager.getInstance().GetCommandResult();
        }


        /// <summary>
        /// Changes the value of the specified object property.
        /// </summary>
        /// <param name="object_name">Object name.</param>
        /// <param name="index">Object property index. It can be any of object properties enumeration values.</param>
        /// <param name="value">New value of the given property.</param>
        /// <returns></returns>
        public bool ObjectSet(
            string object_name,
            ObjectProperty index,
            Object value)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_name);
            parameters.Add((int)index);
            parameters.Add(value);

            CommandManager.getInstance().ExecCommand(Command.ObjectSet, parameters);
            while (CommandManager.getInstance().IsCommandRunning()) Thread.Sleep(1);
            return (bool)CommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Returns the value of the specified object property.
        /// </summary>
        /// <param name="object_name">Object name.</param>
        /// <param name="index">Object property index. It can be any of object properties enumeration values.</param>
        /// <returns></returns>
        public bool ObjectGet(
            string object_name,
            ObjectProperty index)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_name);
            parameters.Add((int)index);

            CommandManager.getInstance().ExecCommand(Command.ObjectGet, parameters);
            while (CommandManager.getInstance().IsCommandRunning()) Thread.Sleep(1);
            return (bool)CommandManager.getInstance().GetCommandResult();
        }


        /// <summary>
        /// Returns the value of the specified object property.
        /// </summary>
        /// <param name="chart_id">Chart identifier</param>
        /// <param name="object_name">Object name.</param>
        /// <returns>If successful the function returns the number of the subwindow (0 means the main window of the chart), in which the object is found. If the object is not found, the function returns a negative number.</returns>
        public int ObjectFind(
            long chart_id,
            string object_name)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(chart_id);
            parameters.Add(object_name);

            CommandManager.getInstance().ExecCommand(Command.ObjectFind1, parameters);
            while (CommandManager.getInstance().IsCommandRunning()) Thread.Sleep(1);
            return (int)CommandManager.getInstance().GetCommandResult();
        }

        /// <summary>
        /// Returns the value of the specified object property.
        /// </summary>
        /// <param name="chart_id">Chart identifier</param>
        /// <param name="object_name">Object name.</param>
        /// <returns>If successful the function returns the number of the subwindow (0 means the main window of the chart), in which the object is found. If the object is not found, the function returns a negative number.</returns>
        public int ObjectFind(
            string object_name)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_name);

            CommandManager.getInstance().ExecCommand(Command.ObjectFind2, parameters);
            while (CommandManager.getInstance().IsCommandRunning()) Thread.Sleep(1);
            return (int)CommandManager.getInstance().GetCommandResult();
        }


        /// <summary>
        /// The function changes the object description.
        /// </summary>
        /// <param name="object_name">Object name.</param>
        /// <param name="text">A text describing the object.</param>
        /// <param name="font_size">Font size in points.</param>
        /// <param name="font_name">Font name.</param>
        /// <param name="font_color">Font color.</param>
        /// <returns>Changes the object description.  If the function succeeds, the returned value will be true, otherwise false</returns>
        public bool ObjectSetText(
            string object_name,
            string text,
            int font_size = 0,
            string font_name = null,
            Color text_color = Color.NONE)
        {
            List<Object> parameters = new List<Object>();
            parameters.Add(object_name);
            parameters.Add(text);
            parameters.Add(font_size);
            parameters.Add(font_name);
            parameters.Add((int)text_color);

            CommandManager.getInstance().ExecCommand(Command.ObjectSetText, parameters);
            while (CommandManager.getInstance().IsCommandRunning()) Thread.Sleep(1);
            return (bool)CommandManager.getInstance().GetCommandResult();
        }
    }
}