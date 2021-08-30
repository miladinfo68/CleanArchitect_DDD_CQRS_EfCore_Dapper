using System;
using _1_App.Core.Domain.Abstracts.Interfaces;

namespace _1_App.Core.Domain.Entities
{
    public class Duty : IEntity
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DutyStatus Status { get; set; }
        public string CreatedAt { get; init; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        public decimal EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }

    public enum DutyStatus
    {
        Created = 1,
        Active = 2,
        Done = 3
    }
}
