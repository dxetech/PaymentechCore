using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentechCore.Services
{
    public static class PaymentechHelpers
    {
        public static string RemoveControlCharacters(string input)
        {
            return new string(input.Where(c => !char.IsControl(c)).ToArray());
        }

        public static string SanitizeAddressFields(string input)
        {
            var stripChars = new char[] { '%', '|', '^', '\\', '/' };
            return new string(input.Where(c => !stripChars.Contains(c)).ToArray());
        }

        public static string SanitizePhoneFields(string input)
        {
            var stripChars = new char[] { '(', ')', '-', '.' };
            return new string(input.Where(c => !stripChars.Contains(c)).ToArray());
        }

        public static string CardType(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 1)
            {
                return null;
            }

            var chars = input.Trim().ToCharArray();
            if (chars[0] == '4')
            {
                return "Visa";
            }
            if (chars[0] == '5')
            {
                return "MC";
            }
            if (chars[0] == '6')
            {
                return "Discover";
            }
            if (new List<string>() { "34", "37" }.Contains(input.Trim().Substring(0, 2)))
            {
                return "Amex";
            }
            if (new List<string>() { "2131", "1800" }.Contains(input.Trim().Substring(0, 4)))
            {
                return "JCB";
            }
            return null;
        }

        public static string ConvertAmount(string input)
        {
            // Remove decimal, pad zeros for ints
            // e.g
            // 45.25 -> 4525
            // 54 -> 5400
            if (input == null)
            {
                return null;
            }
            if (input.Length == 0)
            {
                return "00";
            }
            var a = input.Split('.');
            if (a.Length == 0)
            {
                return $"{a}00";
            }
            else
            {
                var dec = a[1];
                if (dec.Length == 1)
                {
                    return $"{a[0]}{dec}0";
                }
                else if (dec.Length == 2)
                {
                    return $"{a[0]}{dec}";
                }
            }
            return null;
        }

        public static string ConvertAmount(decimal input)
        {
            var d = decimal.Round(input, 2);
            return ConvertAmount(d.ToString());
        }
    }
}