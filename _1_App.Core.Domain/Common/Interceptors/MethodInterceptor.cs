using Castle.DynamicProxy;
using System;

namespace _1_App.Core.Domain.Common.Interseptors
{
    public class MethodInterceptor : CustomInterceptorAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, Exception ex) { }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try { invocation.Proceed(); }
            catch (Exception ex)
            {
                isSuccess = false;
                OnException(invocation, ex);
                throw;
            }
            finally { if (isSuccess) OnSuccess(invocation); }
            OnAfter(invocation);
        }

    }
}
