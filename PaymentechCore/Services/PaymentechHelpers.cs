using PaymentechCore.Models.RequestModels;
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
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            var trimmed = input.Trim();
            if (trimmed.Length < 1)
            {
                return null;
            }

            var chars = trimmed.ToCharArray();
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
            if (trimmed.Length < 2)
            {
                return null;
            }
            if (new List<string>() { "34", "37" }.Contains(trimmed.Substring(0, 2)))
            {
                return "Amex";
            }
            if (trimmed.Length < 4)
            {
                return null;
            }
            if (new List<string>() { "2131", "1800" }.Contains(trimmed.Substring(0, 4)))
            {
                return "JCB";
            }
            return null;
        }

        public static string CardSecValInd(NewOrderType order)
        {
            // Card Security Presence Indicator
            // For Discover/Visa
            // 1     Value is Present
            // 2     Value on card but illegible
            // 9     Cardholder states data not available
            // null if not Visa/Discover
            if (string.IsNullOrEmpty(order.CardSecVal))
            {
                return null;
            }
            var cardType = CardType(order.AccountNum);
            if (cardType == "Visa" || cardType == "Discover")
            {
                if (!string.IsNullOrEmpty(order.Exp))
                {
                    return "1";
                }
                else
                {
                    return "9";
                }
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
            var trimmed = input.Trim();
            var a = trimmed.Split('.');
            if (trimmed.Length == 0 || a.Length == 0)
            {
                return "00";
            }
            if (a.Length == 1)
            {
                return $"{a[0]}00";
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