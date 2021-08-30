using _1_App.Core.Domain.Common.Interseptors;
using Castle.DynamicProxy;
using System;
using System.Reflection;
using System.Linq;

namespace _1_App.Core.Domain.Common.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            if (!string.IsNullOrEmpty(type.Name) && type.Name.ToLower().Contains("command")) return interceptors;
            var classAttributes = type.GetCustomAttributes<CustomInterceptorAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name)?.GetCustomAttributes<CustomInterceptorAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(JsonFileLogger)));
            //classAttributes.Add(new ExceptionLogAspect(typeof(DatabaseLogger)));
            //classAttributes.Add(new LogAspect(typeof(DatabaseLogger)));
            return classAttributes.OrderByDescending(x => x.Priority).ToArray();
        }
    }
}
