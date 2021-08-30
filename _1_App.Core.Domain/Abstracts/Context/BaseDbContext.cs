using System.Data;
using System.Threading;
using System.Threading.Tasks;
using _1_App.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace _1_App.Core.Domain.Abstracts.Context
{
    public abstract class BaseDbContext : DbContext 
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }
        //public IDbConnection Connection { get; }
        //public DatabaseFacade Database { get; }
        public IDbConnection Connection => Database.GetDbConnection();

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Duty> Duties { get; set; }
        
    }

    //public interface IApplicationDbContext
    //{
    //    IDbConnection Connection { get; }
    //    DatabaseFacade Database { get; }

    //    DbSet<Employee> Employees { get; set; }
    //    DbSet<Department> Departments { get; set; }
    //    DbSet<Duty> Duties { get; set; }

    //    Task<int> SaveChangesAsync(CancellationToken cancellationToken=default);
    //}
}
