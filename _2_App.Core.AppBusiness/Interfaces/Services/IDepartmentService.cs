using _2_App.Dtos.Department;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _2_App.Core.Apllication.Interfaces
{
    public interface IDepartmentService 
    {
        Task<List<DepartmentDto>> GetAllDepartmentsAsync();
        Task<DepartmentDto> GetDepartmentByIdAsync(GetByIdDepartmentDto getByIdDepartmentDto);
        Task<DepartmentDto> AddDepartmentAsync(AddDepartmentDto addDepartmentDto);
        Task<DepartmentDto> UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto);
        ValueTask<bool> DeleteDepartmentAsync(DeleteDepartmentDto deleteDepartmentDto);
    }
}
