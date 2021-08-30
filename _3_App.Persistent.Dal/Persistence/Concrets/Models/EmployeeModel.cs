using _1_App.Core.Domain.Entities;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.Models
{
    public class EmployeeModel
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreatedAt { get; init; } 
        public decimal DepartmentId { get; set; }
    }

    public class DepartmentModel 
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; init; } 
    }

    public class DutyModel
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DutyStatus Status { get; set; }
        public string CreatedAt { get; init; } 
        public decimal EmployeeId { get; set; }
    }
}
