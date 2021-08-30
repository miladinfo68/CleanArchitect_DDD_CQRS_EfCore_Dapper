using System.Collections.Generic;
using System.Threading.Tasks;
using _1_App.Core.Domain.Common.Execptions;
using _1_App.Core.Domain.Common.Response;
using _2_App.Core.Apllication.Interfaces;
using _2_App.Dtos.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _3_1_App.Persistent.Dal.Persistence.Concrets.RequestValidator.Employee;
namespace _4_App.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ApiController
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(
              ILogger<EmployeeController> logger
            , IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }


        [HttpGet("get-all")]
        public async Task<ApiResponse<List<EmployeeDto>>> GetAll()
        {
            //throw new CustomException("An error occurred...");
            //var employees = await _employeeService.GetAllAsync();
            var employees = await _employeeService.GetAllAsync();
            return ApiResponse<List<EmployeeDto>>.Success(employees);
        }

        [HttpGet("get-one")]
        public async Task<ApiResponse<EmployeeDto>> Get(decimal id)
        {
            //var employee = await _employeeService.GetByIdAsync(new GetByIdEmployeeDto { Id = id });
            var employee = await _employeeService.GetByIdAsync(new GetByIdEmployeeDto { Id = id });
            if (employee is null)
                return ApiResponse<EmployeeDto>.Fail(ResponseMessages.NOT_FOUND);
            return ApiResponse<EmployeeDto>.Success(employee, ResponseMessages.SUCCESS);
        }


        [HttpPost("add")]
        public async Task<ApiResponse<EmployeeDto>> Add(AddEmployeeDto addEmployeeDto)
        {
            //var employee = await _employeeService.AddAsync(addEmployeeDto);
            var employee = await _employeeService.AddAsync(addEmployeeDto);
            return ApiResponse<EmployeeDto>.Success(employee, ResponseMessages.SUCCESS);
        }

        [HttpPut("update")]
        public async Task<ApiResponse<EmployeeDto>> Update(UpdateEmployeeDto updateEmployeeDto)
        {
            //var employee = await _employeeService.UpdateAsync(updateEmployeeDto);
            var employee = await _employeeService.UpdateAsync(updateEmployeeDto);
            return ApiResponse<EmployeeDto>.Success(employee, ResponseMessages.SUCCESS);
        }

        [HttpDelete("delete")]
        public async Task<ApiResponse<EmployeeDto>> Delete(decimal id)
        {
            //var result = await _employeeService.DeleteAsync(new DeleteEmployeeDto { Id = id });
            var result = await _employeeService.DeleteAsync(new DeleteEmployeeDto { Id = id });
            if (!result)
                return ApiResponse<EmployeeDto>.Fail(ResponseMessages.OPERATION_FAIL);
            return ApiResponse<EmployeeDto>.Success(null, ResponseMessages.SUCCESS);
        }
    }
}
