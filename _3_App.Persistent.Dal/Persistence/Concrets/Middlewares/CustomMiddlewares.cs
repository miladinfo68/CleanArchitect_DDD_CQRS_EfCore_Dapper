using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using _3_1_App.Persistent.Dal.DataAccess;
using System.Data.Common;
using System;
using System.Data;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.Middlewares
{
    public static class CustomMiddlewares
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, string conn)
        {
            var dataAssemblyName = typeof(MyDbContext).Assembly.GetName().Name;
            services.AddDbContext<MyDbContext>(options => options
             .UseSqlServer(conn, x => x.MigrationsAssembly(dataAssemblyName))
             .EnableSensitiveDataLogging(true)
             );
            return services;
        }


    }
}
