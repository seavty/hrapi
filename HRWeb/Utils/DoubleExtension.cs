using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRWeb.Utils
{
    public static class DoubleExtension
    {
        public static string ToTwoDecimalPoint(this double value)
        {
            return value.ToString("0.00");
        }

        public static string ThousandSeparator(this double value)
        {
            return value.ToString("#,##0.00");
        }

        public static string ThousandSeparator_Decimal(this decimal? value)
        {
            return decimal.Parse(value.ToString()).ToString("#,##0.00");
        }

    }
}