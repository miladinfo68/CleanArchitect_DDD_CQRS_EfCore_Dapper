using _1_App.Core.Domain.Abstracts.Interfaces.IRepositories;
using _1_App.Core.Domain.Entities;
using _2_App.Core.AppBusiness.Interfaces.Repositories;
using _3_1_App.Persistent.Dal.DataAccess;
using Microsoft.Extensions.Configuration;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.Repositories
{
    public class DepartmentRepository :ApplicationBaseRepository<Department>
        , IDepartmentRepository
    {
        public DepartmentRepository(MyDbContext context , IConfiguration configuration) : base(context, configuration)
        {
        }
    }
}
