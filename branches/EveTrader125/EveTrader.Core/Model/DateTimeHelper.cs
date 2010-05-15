using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EveTrader.Core.Model
{
    /// <summary>
    /// This class is a hack for Microsoft's stupidity concerning DateTime.Date in Linq to Entity
    /// </summary>
    [DebuggerDisplay("{Day}.{Month}.{Year} {Hour}:{Minute}:{Second}")]
    public class DateTimeHelper
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public static implicit operator DateTimeHelper(DateTime input)
        {
            return new DateTimeHelper() { Year = input.Year, Month = input.Month, Day = input.Day, Hour = input.Hour, Minute = input.Minute, Second = input.Second };
        }
        public static implicit operator DateTime(DateTimeHelper input)
        {
            return new DateTime(input.Year, input.Month, input.Day, input.Hour, input.Minute, input.Second);
        }
    }
}
