using _1_App.Core.Domain.Common.Interseptors;
using Castle.DynamicProxy;
using System;
using System.Transactions;

namespace _1_App.Core.Domain.Common.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterceptor
    {
        public override void Intercept(IInvocation invocation)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeOption.Required ,TimeSpan.FromMinutes(10) ))
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (System.Exception ex)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
