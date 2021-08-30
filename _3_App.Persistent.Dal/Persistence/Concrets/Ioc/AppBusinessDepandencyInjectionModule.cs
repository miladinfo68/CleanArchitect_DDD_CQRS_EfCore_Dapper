using System.Reflection;
using _1_App.Core.Domain.Abstracts.Interfaces.IRepositories;
using _1_App.Core.Domain.Abstracts.Interfaces.IRepositories.Dapper;
using _1_App.Core.Domain.Common.Interceptors;
using _2_App.Core.Apllication.Interfaces;
using _2_App.Core.AppBusiness.Interfaces.Repositories;
using _3_1_App.Persistence.Concrets.Mapper;
using _3_1_App.Persistent.Dal.DataAccess;
using _3_1_App.Persistent.Dal.Persistence.Concrets.Repositories;
using _3_1_App.Persistent.Dal.Persistence.Concrets.Services;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore;

namespace _3_1_App.Persistence.Concrets.Ioc
{
    public  class AppBusinessDepandencyInjectionModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType(typeof(AppDbContext)).As(typeof(DbContext)).SingleInstance();
 
            
            builder.RegisterType<DepartmentService>().As<IDepartmentService>().InstancePerRequest();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerRequest();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterType(typeof(EmployeeRepository)).As(typeof(IEmployeeRepository));
            builder.RegisterType(typeof(DepartmentRepository)).As(typeof(IDepartmentRepository));
            builder.RegisterType(typeof(DutyRepository)).As(typeof(IDutyRepository));

            //builder.RegisterType(typeof(DapperBaseRepositoryOnlyRead)).As(typeof(DapperCustomReadRepository));


            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
      
}
