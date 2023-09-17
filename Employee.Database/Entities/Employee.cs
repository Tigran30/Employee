using System;
using System.Collections.Generic;

namespace Employee.Database.Entities
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Gender { get; set; } = null!;
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public string City { get; set; } = null!;
        public string Postal { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
