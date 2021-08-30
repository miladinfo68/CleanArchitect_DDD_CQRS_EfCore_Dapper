using System;
using System.Collections.Generic;
using _1_App.Core.Domain.Abstracts.Interfaces;

namespace _1_App.Core.Domain.Entities
{
    public class Department:IEntity
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedAt { get; init; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //virtual to enable lazyloading
        public virtual List<Employee> Employees { get; set; }       
    }
}
