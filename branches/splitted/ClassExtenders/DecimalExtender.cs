namespace ClassExtenders
{
    public static class DecimalExtender
    {
        public static string FormatCurrency(this decimal value)
        {
            return value.ToString("n", System.Globalization.CultureInfo.GetCultureInfo("ru-RU").NumberFormat);
        }
    }
}
