using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Employee.Core.Helper
{
    public static class StringHelper
    {
        public static bool IsEmailValid(string email)
        {
            var emailRegex = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
            return emailRegex.IsMatch(email);
        }  
        public static bool IsPhoneNumberValid(string number)
        {
            var emailRegex = new Regex("\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{4}");
            return emailRegex.IsMatch(number);
        }

    }
}
