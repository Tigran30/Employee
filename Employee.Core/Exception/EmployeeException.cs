using Employee.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Exception
{
    public class EmployeeException : System.Exception
    {
        public ResponseCode Code { get; set; }

        public EmployeeException()
        {
        }

        public EmployeeException(ResponseCode code, string? message = null)
            : base(message)
        {
            Code = code;
        }

        public EmployeeException(string message)
            : base(message)
        {
        }
    }
}
