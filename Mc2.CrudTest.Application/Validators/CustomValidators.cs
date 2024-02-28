using FluentValidation;
using FluentValidation.Validators;

namespace Mc2.CrudTest.Application.Validators;

public static class CustomValidators
{
    public static IRuleBuilderOptions<T, string> MatchPhoneNumberRule<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new RegularExpressionValidator<T>(@"((?:[0-9]\-?){6,14}[0-9]$)|((?:[0-9]\x20?){6,14}[0-9]$)"));
    }
}
