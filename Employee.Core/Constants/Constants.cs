using Employee.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Constants
{
    public static class Constants
    {
        public static Dictionary<ResponseCode, string> GetExceptionMessages()
        {
            var messages = new Dictionary<ResponseCode, string>() {
                { ResponseCode.InternalServerError, "Internal error"},
                { ResponseCode.InvalidEmail, "Email is invalid"},
                { ResponseCode.InvalidPhone, "Phone number is Invalid"},
                { ResponseCode.EmployeeNotFound, "Employee is not found"},
            };

            return messages;
        }
    }
}
