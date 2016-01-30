using System;
using MQL4CSharp.Base;
using NodaTime;

namespace mqlsharp.Util
{
    public class DateUtil
    {
        public static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        public static string ToMT4TimeString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy.MM.dd HH:mm");
        }

        public static DateTime getDateFromCurrentAnd24HRTime(DateTime current, String hr24Time)
        {
            TimeSpan time = new TimeSpan(Int32.Parse(hr24Time.Split(':')[0]), Int32.Parse(hr24Time.Split(':')[1]), 0);
            DateTime date = current.Date;
            return date + time;
        }

        public static DateTime addDateAndTime(LocalDate date, LocalTime time)
        {
            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
        }
    }
}
