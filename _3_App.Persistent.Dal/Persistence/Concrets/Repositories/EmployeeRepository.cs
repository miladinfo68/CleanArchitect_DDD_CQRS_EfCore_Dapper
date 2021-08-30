using _1_App.Core.Domain.Abstracts.Interfaces.IRepositories;
using _1_App.Core.Domain.Abstracts.Interfaces.IRepositories.Dapper;
using _1_App.Core.Domain.Entities;
using _2_App.Core.AppBusiness.Interfaces.Repositories;
using _3_1_App.Persistent.Dal.DataAccess;
using Microsoft.Extensions.Configuration;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.Repositories
{
    public class EmployeeRepository : ApplicationBaseRepository<Employee>
        , IEmployeeRepository
    {
        public EmployeeRepository(MyDbContext context , IConfiguration configuration) 
            : base(context, configuration)
        {
        }
    }
}
