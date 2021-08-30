using _2_App.Core.AppBusiness.Interfaces.Repositories;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
              IEmployeeRepository employeeRepository
            , IDepartmentRepository departmentRepository
            , IDutyRepository dutyRepository
            )
        {

            Employees = employeeRepository;
            Departments = departmentRepository;
            Duties = dutyRepository;

        }

        public IEmployeeRepository Employees { get; }
        public IDepartmentRepository Departments { get; }
        public IDutyRepository Duties { get; }
    }
}
