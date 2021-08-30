using _1_App.Core.Domain.Abstracts.Context;
using _1_App.Core.Domain.Abstracts.Interfaces.IRepositories.Dapper;
using _3_1_App.Persistence.Concrets.Mapper;
using _3_1_App.Persistent.Dal.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _3_1_App.Persistence.Concrets.Ioc
{
    public static class AppBusinessDepandencyInjection
    {
        public static IServiceCollection AddAppBusinessDI(this IServiceCollection services)
        {
            services.AddTransient<BaseDbContext>(svcProvider => svcProvider.GetService<MyDbContext>());

            services.AddTransient<DapperCustomReadRepository, DapperBaseRepositoryOnlyRead>();
            //services.AddTransient<IDapperBaseRepository, DapperBaseRepository<MyDbContext>>();

            services.AddAutoMapper(typeof(AutoMappingProfile));
            //services.AddAutoMapper(Assembly.GetExecutingAssembly()); 

         
            return services;
        }
    }
}
