using _1_App.Core.Domain.Entities;
using _1_App.Core.Domain.Abstracts.Interfaces;

namespace _3_1_App.Core.AppBusiness.Dtos.Duty
{
    public class DutyDto : IDto
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        //public string Description { get; set; }
        //public DutyStatus Status { get; set; }
        //public string CreatedAt { get; init; } 
        //public decimal EmployeeId { get; set; }
    }


}
