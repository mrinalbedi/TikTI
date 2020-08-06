using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ValidationClassLibrary
{
    public static class Validations
    {
        public static string Capitalize(string input)
        {
            if (input == null)
            {
                return string.Empty;
            }
            string x = input.ToLower().Trim();
            x = Regex.Replace(x, @"(^\w)|(\s\w)", m => m.Value.ToUpper());

            return x;
        }
        public static string PhoneNumberFormat(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "The Phone number cannot be blank";
            }
            else if (!input.Contains(" "))
            {
                input = input.Insert(0, "(");
                input = input.Insert(4, ")");
                input = input.Insert(5, "-");
                input = input.Insert(9, "-");
                input = input.ToUpper();
            }
            return input;
        }
           
    } 
}
