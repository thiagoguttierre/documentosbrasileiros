using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DocumentosBrasileiros.Helpers
{
    internal static class StringExtensions
    {
        public static string RemoveSpecialChars(this string value)
        {
            return string.IsNullOrEmpty(value) 
                ? string.Empty 
                : new Regex("[;\\\\/:*?\"<>|=&--'.¨$#%-+,!@()_]").Replace(value, "").Replace(" ", "");
        }

        public static string RandomNumbers(this string value, int length)
        {
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                value += rnd.Next(0, 9);
            }
            return value;
        }

        public static bool AllCharsAreEqual(this string value)
        {
            return value.Distinct().Count() == 1;
        }
    }
}
