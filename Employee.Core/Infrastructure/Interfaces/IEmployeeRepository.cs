using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Infrastructure.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<EntityEntry<Database.Entities.Employee>> AddAsync(Database.Entities.Employee entity);
        IQueryable<Database.Entities.Employee> AsQueryable();
        void Delete(Database.Entities.Employee entity);
        Task SaveChangesAsync();
    }
}
