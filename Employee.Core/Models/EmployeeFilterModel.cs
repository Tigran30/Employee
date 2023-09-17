using Employee.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Models
{
    public class EmployeeFilterModel
    {
        public string? NameOrSurname { get; set; }
        public Gender? Gender { get; set; }
        public bool? IsActive { get; set; }
    }
}
