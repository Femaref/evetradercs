using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.ClassExtenders
{
    public static class DateTimeExtender
    {
        public static DateTime LocalizeEveTime(this DateTime value)
        {
            return value.ToLocalTime();
        }
    }
}
