namespace _2_App.Core.AppBusiness.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        IDepartmentRepository Departments { get; }
        IDutyRepository Duties { get; }
    }
}
