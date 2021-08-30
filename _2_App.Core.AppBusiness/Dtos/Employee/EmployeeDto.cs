using _1_App.Core.Domain.Abstracts.Interfaces;
using _2_App.Dtos.Department;
using _3_1_App.Core.AppBusiness.Dtos.Duty;
using System.Collections.Generic;

namespace _2_App.Dtos.Employee
{
    public class EmployeeDto : IDto
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //public string CreatedAt { get; set; }
        //public decimal DepartmentId { get; set; }
        public DepartmentNameDto Department { get; set; }
        public List<DutyDto> Duties { get; set; }
    }
}
