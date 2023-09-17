using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Enums
{
    public enum ResponseCode : int
    {
        Success = 0,
        InternalServerError = 1,
        EmployeeNotFound = 2,
        InvalidEmail = 3,
        InvalidPhone = 4
    }
}
