using _1_App.Core.Domain.Abstracts.Interfaces;

namespace _2_App.Dtos.Department
{
    public class AddDepartmentDto:IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
