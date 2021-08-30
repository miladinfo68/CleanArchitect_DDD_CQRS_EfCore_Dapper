using _1_App.Core.Domain.Abstracts.Context;
using _1_App.Core.Domain.Abstracts.Interfaces.IRepositories.Dapper;
using _1_App.Core.Domain.Common.Behaviours;
using _1_App.Core.Domain.Common.Ioc;
using _1_App.Core.Domain.Common.Middlewares;
using _2_App.Core.Apllication.Interfaces;
using _2_App.Core.AppBusiness.Interfaces.Repositories;
using _3_1_App.Persistence.Concrets.Ioc;
using _3_1_App.Persistent.Dal.DataAccess;
using _3_1_App.Persistent.Dal.Persistence.Concrets.Middlewares;
using _3_1_App.Persistent.Dal.Persistence.Concrets.Repositories;
using _3_1_App.Persistent.Dal.Persistence.Concrets.Services;
using Autofac;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;

namespace _4_App.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //ConnString ??= Configuration.GetConnectionString("DefaultConnection");
        }

        public IConfiguration Configuration { get; }
        //public string ConnString { get; init; }
        //public IDbConnection DbConnection => new SqlConnection(Configuration.GetConnectionString("DefaultConnection"));

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var defaultConnectionString = Configuration.GetConnectionString("DefaultConnection");
            //services.AddSingleton(defaultConnectionString);           
            services.AddCustomDbContext(defaultConnectionString);

            var dataAssemblyName = typeof(MyDbContext).Assembly.GetName().Name;
            services.AddDbContext<MyDbContext>(options => options
             .UseSqlServer(defaultConnectionString, x => x.MigrationsAssembly(dataAssemblyName))
             .EnableSensitiveDataLogging(true)
             );
            
            services.AddAppCoreDI();
            ServiceTool.AddCoreServiceResolver(services);
            services.AddAppBusinessDI();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "_4_App.WebApi", Version = "v1" });
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "_4_App.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
