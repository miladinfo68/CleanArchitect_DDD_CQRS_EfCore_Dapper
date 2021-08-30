using _1_App.Core.Domain.Abstracts.Interfaces;
using _2_App.Dtos.Department;

namespace _2_App.Dtos.Employee
{
    public class AddEmployeeDto : IDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal DepartmentId { get; set; }
        //public DepartmentDto Department { get; set; }
    }

   
       
}
