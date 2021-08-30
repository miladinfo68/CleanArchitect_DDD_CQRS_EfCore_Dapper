using FluentValidation;
using FluentValidation.Validators;

namespace _1_App.Core.Domain.Common.Middlewares
{
    public static class CustomRuleForValidation
    {
        private static string emailPattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        private static string phoneNoPattern = @"((?:[0-9]\-?){6,14}[0-9]$)|((?:[0-9]\x20?){6,14}[0-9]$)";

        public static IRuleBuilderOptions<T, string> MatchEmailRule<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new RegularExpressionValidator<T>(emailPattern));
        }
        public static IRuleBuilderOptions<T, string> MatchPhoneNumberRule<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new RegularExpressionValidator<T>(phoneNoPattern));
        }
    }
}
