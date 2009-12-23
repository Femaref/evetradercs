using System;
using System.Globalization;

namespace EveObjects
{
    public static class StringExtender
    {
        public static bool IsEmpty (this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        public static int ToInt32 (this string str)
        {
            return Convert.ToInt32(str);
        }
        public static double ToDouble (this string str)
        {
            CultureInfo EnCulture = new CultureInfo("en-US");
            return Convert.ToDouble(str, EnCulture.NumberFormat);
        }
        public static DateTime ToDateTime (this string str)
        {
            return Convert.ToDateTime(str);
        }
    }
}
