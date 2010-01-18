using System;

namespace Core.ClassExtenders
{
    public static class StringExtender
    {
        public static bool IsEmpty (this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        public static int ToInt32 (this string str)
        {
            return int.Parse(
                str,
                System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.GetCultureInfo("en-US").NumberFormat);
        }
        public static long ToInt64(this string str)
        {
            return long.Parse(
                str,
                System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.GetCultureInfo("en-US").NumberFormat);
        }
        public static double ToDouble (this string str)
        {
            return double.Parse(
                str,
                System.Globalization.NumberStyles.Number,
                System.Globalization.CultureInfo.GetCultureInfo("en-US").NumberFormat);
        }
        public static decimal ToDecimal(this string str)
        {
            return decimal.Parse(str);
        }
        public static DateTime ToDateTime (this string str)
        {
            return Convert.ToDateTime(str);
        }
        public static string StringFormat (this string str, params object[] args)
        {
            return string.Format(str, args);
        }
        public static string StringFormat (this string str, object args)
        {
            return string.Format(str, args);
        }

    }
}
