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
    public class DateTimeHelper : IComparable<DateTimeHelper>
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

        public static bool operator == (DateTimeHelper dth, DateTime dt)
        {
            return dth.Year == dt.Year && dth.Month == dt.Month && dth.Day == dt.Day && dth.Hour == dt.Hour && dth.Minute == dt.Minute && dth.Second == dt.Second;
        }

        public static bool operator !=(DateTimeHelper dth, DateTime dt)
        {
            return !(dth == dt);
        }

        #region IComparable<DateTimeHelper> Members

        public int CompareTo(DateTimeHelper other)
        {
            bool res = this.Year > other.Year && this.Month > other.Month && this.Day > other.Day && this.Hour > other.Hour && this.Minute > other.Minute && this.Second > other.Second;
            if (res)
                return 1;
            if (!res)
                return -1;
            return 0;
        }

        #endregion
    }
}
