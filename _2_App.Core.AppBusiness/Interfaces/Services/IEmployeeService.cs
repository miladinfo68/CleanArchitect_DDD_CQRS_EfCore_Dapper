using _2_App.Dtos.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;
using _1_App.Core.Domain.Abstracts.Interfaces;
using _1_App.Core.Domain.Abstracts.Interfaces.IServices;

namespace _2_App.Core.Apllication.Interfaces
{
    public interface IEmployeeService :
          IBaseService<EmployeeDto>
        , IBaseServiceGetById<GetByIdEmployeeDto, EmployeeDto>
        , IBaseServiceAdd<AddEmployeeDto, EmployeeDto>
        , IBaseServiceUpdate<UpdateEmployeeDto, EmployeeDto>
        , IBaseServiceDelete<DeleteEmployeeDto>
    {
    }
    /*
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(GetByIdEmployeeDto getByIdEmployeeDto);
        Task<EmployeeDto> AddEmployeeAsync(AddEmployeeDto addEmployeeDto);
        Task<EmployeeDto> UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto);
        ValueTask<bool> DeleteEmployeeAsync(DeleteEmployeeDto deleteEmployeeDto);
    }
    */
}
