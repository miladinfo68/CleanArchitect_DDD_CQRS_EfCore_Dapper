using _1_App.Core.Domain.Abstracts.Interfaces;

namespace _2_App.Dtos.Employee
{
    public class DeleteEmployeeDto : IDto
    {
        public decimal Id { get; set; }
    }
}
