﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Models
{
    public class EmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } 
        public string Address1 { get; set; } 
        public string? Address2 { get; set; }
        public string City { get; set; }
        public string Postal { get; set; } 
        public string Country { get; set; }
        public string Email { get; set; } 
        public string Mobile { get; set; } 
        public bool IsActive { get; set; }
    }
}
