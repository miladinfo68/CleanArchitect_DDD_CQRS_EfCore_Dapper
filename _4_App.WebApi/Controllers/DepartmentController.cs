using System.Collections.Generic;
using System.Threading.Tasks;
using _1_App.Core.Domain.Common.Aspects.Autofac.Transaction;
using _1_App.Core.Domain.Common.Response;
using _2_App.Core.Apllication.Interfaces;
using _2_App.Dtos.Department;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _4_App.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ApiController
    {

        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentService _departmentService;
        public DepartmentController(
              ILogger<DepartmentController> logger
            , IDepartmentService departmentService
            , IEmployeeService employeeService)
        {
            _logger = logger;
            _departmentService = departmentService;
        }

        [HttpGet("get-all")]
        public async Task<ApiResponse<List<DepartmentDto>>> GetAll()
        {
            //var departments = await _departmentService.GetAllAsync();
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return ApiResponse<List<DepartmentDto>>.Success(departments);
        }

        [HttpGet("get-one")]
        public async Task<ApiResponse<DepartmentDto>> Get(decimal id)
        {
            //var department = await _departmentService.GetByIdAsync(new GetByIdDepartmentDto { Id = id });
            var department = await _departmentService.GetDepartmentByIdAsync(new GetByIdDepartmentDto { Id = id });
            if (department is null)
                return ApiResponse<DepartmentDto>.Fail(ResponseMessages.NOT_FOUND);
            return ApiResponse<DepartmentDto>.Success(department, ResponseMessages.SUCCESS);
        }


        [HttpPost("add")]
        public async Task<ApiResponse<DepartmentDto>> Add(AddDepartmentDto departmentDto)
        {
            //var department = await _departmentService.AddAsync(departmentDto);
            var department = await _departmentService.AddDepartmentAsync(departmentDto);
            if (department.Id <= 0) return ApiResponse<DepartmentDto>.Fail(ResponseMessages.OPERATION_FAIL);
            return ApiResponse<DepartmentDto>.Success(department);
            
        }

        [HttpPut("update")]

        public async Task<ApiResponse<DepartmentDto>> Update(UpdateDepartmentDto departmentDto)
        {
            //var department = await _departmentService.UpdateAsync(departmentDto);
            var department = await _departmentService.UpdateDepartmentAsync(departmentDto);
            return ApiResponse<DepartmentDto>.Success(department, ResponseMessages.SUCCESS);
        }

        [HttpDelete("delete")]
        public async Task<ApiResponse<DepartmentDto>> Delete(decimal id)
        {
            //var result = await _departmentService.DeleteAsync(new DeleteDepartmentDto { Id = id });
            var result = await _departmentService.DeleteDepartmentAsync(new DeleteDepartmentDto { Id = id });
            if (!result)
                return ApiResponse<DepartmentDto>.Fail(ResponseMessages.OPERATION_FAIL);
            return ApiResponse<DepartmentDto>.Success(null, ResponseMessages.SUCCESS);
        }
    }
}
