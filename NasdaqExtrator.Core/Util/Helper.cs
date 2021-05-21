using System;
using System.Globalization;

namespace NasdaqExtrator.Core.Util
{
    public static class Helper
    {
        public static DateTime ParseNasdaqDate(string dateText)
        {
            var date = DateTime.ParseExact(dateText, "MM/dd/yyyy", new CultureInfo("en-US"));
            return date;
        }

        public static decimal ParseNasdaqValue(string valueText)
        {
            if (string.IsNullOrWhiteSpace(valueText))
            {
                return 0;
            }

            var cleanValueText = valueText.Replace("$", string.Empty);

            var value = Convert.ToDecimal(cleanValueText, new CultureInfo("en-US"));
            return value;
        }
    }
}
