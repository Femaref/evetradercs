using System;

namespace EveTrader.Core.ClassExtenders
{
    public static class StringExtender
    {
        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        public static int ToInt32(this string str)
        {
            int output;
            if (int.TryParse(
                str,
                System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.GetCultureInfo("en-US").NumberFormat, out output))
                return output;
            else
                return 0;
        }
        public static long ToInt64(this string str)
        {
            long output;
            if (long.TryParse(
                str,
                System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.GetCultureInfo("en-US").NumberFormat, out output))
                return output;
            else
                return 0;
        }
        public static double ToDouble(this string str)
        {
            double output;
            if (double.TryParse(
                str,
                System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.GetCultureInfo("en-US").NumberFormat, out output))
                return output;
            else
                return 0;
        }
        public static decimal ToDecimal(this string str)
        {
            decimal output;
            if (decimal.TryParse(
                str,
                System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.GetCultureInfo("en-US").NumberFormat, out output))
                return output;
            else
                return 0;
        }

        public static DateTime ToDateTime(this string str)
        {
            return Convert.ToDateTime(str);
        }
    }
}
