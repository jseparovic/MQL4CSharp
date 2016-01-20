using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
