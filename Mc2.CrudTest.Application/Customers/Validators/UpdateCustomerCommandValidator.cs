using FluentValidation;
using Mc2.CrudTest.Application.Contract.Customers.Commands;
using PhoneNumbers;

namespace Mc2.CrudTest.Application.Customers.Validators;

internal class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty();

        RuleFor(c => c.Firstname)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(c => c.Lastname)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(c => c.DateOfBirth)
            .NotEmpty()
            .LessThan(DateTime.Now.AddYears(-18))
            .GreaterThan(DateTime.Now.AddYears(-150));

        RuleFor(c => c.PhoneNumber)
            .NotEmpty()
            .Must(IsValidPhoneNumber)
            .WithMessage("Phone number is not valid.");

        RuleFor(c => c.Email)
            .NotEmpty()
            .MaximumLength(100)
            .EmailAddress();

        RuleFor(c => c.BankAccountNumber)
            .NotEmpty();
    }

    private bool IsValidPhoneNumber(string phoneNumber)
    {
        var lib = PhoneNumberUtil.GetInstance();
        var number = lib.Parse(phoneNumber, "IR");
        return lib.IsValidNumber(number);
    }
}
