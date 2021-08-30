using _1_App.Core.Domain.Abstracts.Interfaces;

namespace _2_App.Dtos.Employee
{
    public class UpdateEmployeeDto : IDto
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //public string CreatedAt { get; set; }
        public decimal DepartmentId { get; set; }
    }
}
