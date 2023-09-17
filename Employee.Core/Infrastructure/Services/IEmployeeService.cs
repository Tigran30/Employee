using Employee.Core.Models;
using Employee.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Infrastructure.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeResponseModel> GetEmployeeTotalList();
        Task<bool?> AddEmployee(EmployeeModel model);
        Task<bool?> UpdateEmployee(EmployeeUpdateModel model);
        Task<List<EmployeeModel>> GetEmployeesByFilter(EmployeeFilterModel filterModel);
    }
}
