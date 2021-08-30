using _1_App.Core.Domain.Entities;
using _3_1_App.Persistent.Dal.Persistence.ServiceDataModels;
using System.Collections.Generic;
using System.Linq;
using _3_1_App.Persistent.Dal.Persistence.Concrets.Models;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.Mapper
{
    public static class CustomMapper
    {
        public static List<Employee> ToEmployees(this List<EmployeeAndDependenciesModel> model)
        {
            var employeesModel = new List<EmployeeModel>();
            var departmentsModel = new List<DepartmentModel>();
            var dutiesModel = new List<DutyModel>();

            model.ToList().ForEach(item =>
            {
                employeesModel.Add(new EmployeeModel { Id = item.EmployeeId, Name = item.EmployeeName, Email = item.EmployeeEmail, CreatedAt = item.EmployeeCreatedAt, DepartmentId = item.DepartmentId });
                departmentsModel.Add(new DepartmentModel { Id = item.DepartmentId, Name = item.DepartmentName, Description = item.DepartmentDescription, CreatedAt = item.DepartmentCreatedAt });
                dutiesModel.Add(new DutyModel { Id = item.TaskId, Name = item.TaskName, Description = item.TaskDescription, CreatedAt = item.TaskCreatedAt, Status = (DutyStatus)item.TaskStatus ,EmployeeId=item.EmployeeId});
            });

            var employees = employeesModel.GroupBy(g => new { g.Id, g.Name }).Select(s => s.First()).ToList();
            var departments = departmentsModel.GroupBy(g => new { g.Id, g.Name }).Select(s => s.First()).ToList();
            var duties = dutiesModel.GroupBy(g => new { g.Id, g.Name }).Select(s => s.First()).ToList();

            var finalEmployees = new List<Employee>();
            employees.ForEach(emp =>
            {
                var dep = departments.SingleOrDefault(f => f.Id == emp.DepartmentId);
                var department = new Department { Id = dep.Id, Name = dep.Name, Description = dep.Description, CreatedAt = dep.CreatedAt };

                var dutyList = duties.Where(w => w.EmployeeId == emp.Id).ToList();
                
                var convertedToDutyList = new List<Duty>();
                dutyList.ForEach(d => convertedToDutyList.Add(new Duty { Id = d.Id, Name = d.Name, Description = d.Description, CreatedAt = d.CreatedAt }));

                finalEmployees.Add(new Employee
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Email = emp.Email,
                    CreatedAt = emp.CreatedAt,
                    DepartmentId = emp.DepartmentId,
                    Department = department,
                    Duties = convertedToDutyList
                });
            });

            return finalEmployees;
        }

    }
}
