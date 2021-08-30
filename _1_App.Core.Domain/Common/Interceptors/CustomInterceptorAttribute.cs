using System;
using Castle.DynamicProxy;

namespace _1_App.Core.Domain.Common.Interseptors
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomInterceptorAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation invocation) { }
    }
}
