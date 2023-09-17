using Employee.BaseRepository;
using Employee.Core.Infrastructure.Interfaces;
using Employee.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository
{
    public class EmployeeRepository
        : Repository<Database.Entities.Employee>
        , IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDbContext context)
            : base(context) { }
    }
}
