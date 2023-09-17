using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Models.ResponseModels
{
    public class EmployeeResponseModel
    {
        public int TotalEmployees { get; set; }
        public int TotalActiveEmployees { get; set; }
        public int TotalMaleEmployees { get; set; }
        public int TotalFemaleEmployees { get; set; }
    }
}
