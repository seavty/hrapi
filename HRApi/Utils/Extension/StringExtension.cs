using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace HRApi.Utils.Extension
{
    public static class StringExtension
    {
        private static readonly string datetimeFormat = $"{CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern} {CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern}";
       
        //=> ToDateOnly_Client
        public static string ToDateOnly_Client(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";
            DateTime dateTime = DateTime.ParseExact(value, datetimeFormat, CultureInfo.InvariantCulture);
            return dateTime.ToString("dd-MM-yyyy");
        }
    }
}