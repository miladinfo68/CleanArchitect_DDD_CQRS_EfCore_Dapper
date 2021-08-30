using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace _1_App.Core.Domain.Abstracts.Context
{
    public abstract class GenericDbContext<TContext> : DbContext 
    where TContext : DbContext
    {
        private readonly string _connectionString;
        public GenericDbContext(GenericDbContext<TContext> _, IConfiguration configuration) 
            : base(options: 
                  new MyDbContextFactory<TContext>(configuration?.GetConnectionString("DefaultConnection") ?? "")
                  .CreateDbContextOptions()
                  )
        {
            _connectionString = configuration?.GetConnectionString("DefaultConnection") ?? "";
        }       
        public virtual IDbConnection GetConnection() => new SqlConnection(_connectionString);   
    }

    //factory and decorator design pattern
    public sealed class MyDbContextFactory<TDbContext> 
    where TDbContext : DbContext
    {
        private readonly string _connectionString;
        public MyDbContextFactory(string connectionString) => 
        _connectionString = connectionString;
        public DbContextOptions<TDbContext> CreateDbContextOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);
            return optionsBuilder.Options;
        }
    }

    

    /*
    public sealed class MyDbContextFactory<TDbContext> : IDbContextFactory<TDbContext>
        where TDbContext : DbContext
    {
        private readonly string _connString;
        public MyDbContextFactory(string connString) => _connString = connString;
        public TDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TDbContext>();
            optionsBuilder.UseSqlServer(_connString);
            var options = (TDbContext)Activator.CreateInstance(typeof(TDbContext), new object[] { optionsBuilder.Options });
            return options;
            //return new TDbContext(optionsBuilder.Options);
        }
    }
    */

}
