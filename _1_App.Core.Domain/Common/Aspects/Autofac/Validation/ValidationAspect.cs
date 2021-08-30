using _1_App.Core.Domain.Common.Interseptors;
using _1_App.Core.Domain.Common.Messages;
using Castle.DynamicProxy;
using FluentValidation;
using System.Linq;
using System;

namespace _1_App.Core.Domain.Common.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterceptor
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(CoreMessages.WrongValidationType);
            }
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(w => w.GetType() == entityType);
            foreach (var entity in entities)
            {
                Validate(validator, entity);
            }
        }

        private  void Validate<T>(IValidator validator, T entity) where T : class, new()
        {
            var result = validator.Validate(new ValidationContext<T>(entity));
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
