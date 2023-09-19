using Employee.Core.Enums;
using Employee.Core.Exception;
using Employee.Core.Helper;
using Employee.Core.Infrastructure.Interfaces;
using Employee.Core.Infrastructure.Services;
using Employee.Core.Models;
using Employee.Core.Models.ResponseModels;
using Employee.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<EmployeeModel> GetEmployeeById(int id)
        {
            var employee = await employeeRepository
                .AsQueryable()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                throw new EmployeeException(ResponseCode.EmployeeNotFound);
            }
          
            return new EmployeeModel
            {
                Id = employee.Id,
                City = employee.City,
                FirstName = employee.FirstName,
                Address1 = employee.Address1,
                Address2 = employee.Address2,
                Country = employee.Country,
                DateOfBirth = employee.Dob,
                Email = employee.Email,
                Gender = (Gender)Enum.Parse(typeof(Gender), employee.Gender),
                IsActive = employee.IsActive,
                LastName = employee.LastName,
                Mobile = employee.Mobile,
                Postal = employee.Postal
            };
        }

        public async Task<EmployeeResponseModel> GetEmployeeTotalList()
        {
            var employees = await employeeRepository
                .AsQueryable()
                .AsNoTracking()
                .ToListAsync();
            return new EmployeeResponseModel
            {
                TotalEmployees = employees.Count,
                TotalActiveEmployees = employees.Where(x => x.IsActive).ToList().Count,
                TotalFemaleEmployees = employees.Where(x => x.Gender == Gender.Female.ToString()).ToList().Count,
                TotalMaleEmployees = employees.Where(x => x.Gender == Gender.Male.ToString()).ToList().Count,
            };
        }

        public async Task<bool?> AddEmployee(EmployeeModel model)
        {
            if (!StringHelper.IsEmailValid(model.Email))
            {
                throw new EmployeeException(ResponseCode.InvalidEmail);
            }

            if (!StringHelper.IsPhoneNumberValid(model.Mobile))
            {
                throw new EmployeeException(ResponseCode.InvalidEmail);
            }
            var dbModel = new Employee.Database.Entities.Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address1 = model.Address1,
                Address2 = model.Address2,
                City = model.City,
                Country = model.Country,
                Dob = model.DateOfBirth,
                Email = model.Email,
                Gender = model.Gender.ToString(),
                IsActive = model.IsActive,
                Mobile = model.Mobile,
                Postal = model.Postal
            };

            await employeeRepository.AddAsync(dbModel);
            await employeeRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> UpdateEmployee(EmployeeUpdateModel model)
        {
            if (model.Email != null)
            {
                if (!StringHelper.IsEmailValid(model.Email))
                {
                    throw new EmployeeException(ResponseCode.InvalidEmail);
                }
            }
            if (model.Mobile != null)
            {
                if (!StringHelper.IsPhoneNumberValid(model.Mobile))
                {
                    throw new EmployeeException(ResponseCode.InvalidEmail);
                }
            }

            var dbEmployee = await employeeRepository.AsQueryable().FirstOrDefaultAsync(x => x.Id == model.Id);
            if (dbEmployee == null)
            {
                throw new EmployeeException(ResponseCode.EmployeeNotFound);
            }

            dbEmployee.FirstName = model.FirstName ?? dbEmployee.FirstName;
            dbEmployee.LastName = model.LastName ?? dbEmployee.LastName;
            dbEmployee.Address1 = model.Address1 ?? dbEmployee.Address1;
            dbEmployee.Address2 = model.Address2;
            dbEmployee.City = model.City ?? dbEmployee.City;
            dbEmployee.Country = model.Country ?? dbEmployee.Country;
            dbEmployee.Dob = model.DateOfBirth ?? dbEmployee.Dob;
            dbEmployee.Email = model.Email ?? dbEmployee.Email;
            dbEmployee.Gender = model.Gender ?? dbEmployee.Gender;
            dbEmployee.IsActive = model.IsActive ?? dbEmployee.IsActive;
            dbEmployee.Mobile = model.Mobile ?? dbEmployee.Mobile;
            dbEmployee.Postal = model.Postal ?? dbEmployee.Postal;

            await employeeRepository.SaveChangesAsync();
            return true;
        }

        public async Task<List<EmployeeModel>> GetEmployeesByFilter(EmployeeFilterModel filterModel)
        {
            var employees = await (from empolyee in employeeRepository.AsQueryable()
                                   where
                                   filterModel.NameOrSurname != null
                                       ? (empolyee.FirstName == filterModel.NameOrSurname || empolyee.LastName == filterModel.NameOrSurname)
                                       : true
                                   && filterModel.Gender != null
                                       ? empolyee.Gender == filterModel.Gender.Value.ToString()
                                       : true
                                   && filterModel.IsActive != null
                                       ? empolyee.IsActive == filterModel.IsActive.Value
                                       : true
                                   select empolyee).ToListAsync();

            return employees.Select(x => new EmployeeModel
            {
                Id = x.Id,
                City = x.City,
                FirstName = x.FirstName,
                Address1 = x.Address1,
                Address2 = x.Address2,
                Country = x.Country,
                DateOfBirth = x.Dob,
                Email = x.Email,
                Gender = (Gender)Enum.Parse(typeof(Gender),x.Gender),
                IsActive = x.IsActive,
                LastName = x.LastName,
                Mobile = x.Mobile,
                Postal = x.Postal
            }).ToList();
        }

    }
}
