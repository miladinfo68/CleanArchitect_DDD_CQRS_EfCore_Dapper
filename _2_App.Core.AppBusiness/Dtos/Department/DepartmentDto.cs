using _1_App.Core.Domain.Abstracts.Interfaces;

namespace _2_App.Dtos.Department
{
    public class DepartmentDto : IDto
    {
        public decimal Id { get; set; }
        public string Name { get; set; } 
    }

    public class DepartmentNameDto : IDto
    {
        public string Name { get; set; }
    }

}
