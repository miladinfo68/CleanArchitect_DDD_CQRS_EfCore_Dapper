using MediatR;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using _1_App.Core.Domain.Common.Behaviours;
using System.Reflection;
using _1_App.Core.Domain.Common.Middlewares;
using _1_App.Core.Domain.Abstracts.Context;
using System;

namespace _1_App.Core.Domain.Common.Ioc
{
    public static class AppCoreDependencyInjection
    {
        public static IServiceCollection AddAppCoreDI(this IServiceCollection services)
        {          
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

            //services.AddCoreServiceResolver();
            return services;
        }
    }
}
