using System;
using System.Collections.Generic;
using _1_App.Core.Domain.Abstracts.Interfaces;

namespace _1_App.Core.Domain.Entities
{
    public class Employee :IEntity
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreatedAt { get; init; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");        
        public decimal DepartmentId { get; set; }
        public virtual Department Department { get; set; }  
        public virtual List<Duty> Duties { get; set; }
    }
}
