namespace ClassExtenders
{
    public static class DoubleExtender
    {
        public static string FormatCurrency(this double value)
        {
            return value.ToString("n", System.Globalization.CultureInfo.GetCultureInfo("ru-RU").NumberFormat);
        }
    }
}
