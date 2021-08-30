using _1_App.Core.Domain.Abstracts.Interfaces;

namespace _2_App.Dtos.Department
{
    public class UpdateDepartmentDto : IDto
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public string CreatedAt { get; set; }
    }
}
