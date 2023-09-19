using Employee.Core.Infrastructure.Services;
using Employee.Core.Models;
using Employee.Core.Models.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet("GetEmployeesTotalList")]
        [ProducesResponseType(typeof(BaseResponse<EmployeeResponseModel>), 200)]
        public async Task<BaseResponse<EmployeeResponseModel>> GetEmployeesTotalList()
        {
            var result = await employeeService.GetEmployeeTotalList();
            return new BaseResponse<EmployeeResponseModel>
            {
                Result = result,
            };
        } 
        
        [HttpPost("AddEmployee")]
        [ProducesResponseType(typeof(BaseResponse<bool?>), 200)]
        public async Task<BaseResponse<bool?>> AddEmployee(EmployeeModel model)
        {
            var result = await employeeService.AddEmployee(model);
            return new BaseResponse<bool?>
            {
                Result = result,
            };
        }    
        
        [HttpPost("UpdateEmployee")]
        [ProducesResponseType(typeof(BaseResponse<bool?>), 200)]
        public async Task<BaseResponse<bool?>> UpdateEmployee(EmployeeUpdateModel model)
        {
            var result = await employeeService.UpdateEmployee(model);
            return new BaseResponse<bool?>
            {
                Result = result,
            };
        }
        
        [HttpPost("GetEmployeeListByFilter")]
        [ProducesResponseType(typeof(BaseResponse<List<EmployeeModel>>), 200)]
        public async Task<BaseResponse<List<EmployeeModel>>> UpdateEmployee(EmployeeFilterModel model)
        {
            var result = await employeeService.GetEmployeesByFilter(model);
            return new BaseResponse<List<EmployeeModel>>
            {
                Result = result,
            };
        }
        
        [HttpGet("GetEmployeeById")]
        [ProducesResponseType(typeof(BaseResponse<EmployeeModel>), 200)]
        public async Task<BaseResponse<EmployeeModel>> GetEmployeeById(int id)
        {
            var result = await employeeService.GetEmployeeById(id);
            return new BaseResponse<EmployeeModel>
            {
                Result = result,
            };
        }
    }
}
