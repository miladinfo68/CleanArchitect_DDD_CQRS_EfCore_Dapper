using _1_App.Core.Domain.Abstracts.Interfaces;

namespace _2_App.Dtos.Department
{
    public class GetByIdDepartmentDto : IDto
    {
        public decimal Id { get; set; }
    }
}
