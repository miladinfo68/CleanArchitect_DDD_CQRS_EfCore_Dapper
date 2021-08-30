using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_App.Core.Domain.Common.Middlewares
{
    public static class ServiceTool
    {
        private static IServiceProvider _serviceProvider { get; set; }
        public static IServiceCollection AddCoreServiceResolver(IServiceCollection service)
        {
            _serviceProvider = service.BuildServiceProvider();
            return service;
        }
        public static T Resolve<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
