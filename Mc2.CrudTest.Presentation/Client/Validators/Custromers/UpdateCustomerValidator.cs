using FluentValidation;
using Mc2.CrudTest.Presentation.Client.Models.Customers;
using PhoneNumbers;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Presentation.Client.Validators.Custromers
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerDTO>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is requierd.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is requierd.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is requierd.")
                .EmailAddress().WithMessage("Email is not valid.");

            RuleFor(x => x.DateOfBirth)
               .NotNull().WithMessage("Date of birth is requierd.")
               .Must(IsValidDate)
               .WithMessage("Date of Birth is not valid");

            RuleFor(x => new { x.PhoneNumber, x.Country })
               .NotEmpty().WithMessage("Phone number is requierd.")
            .Custom((x, context) => { IsValidPhoneNumber(x.PhoneNumber, x.Country.ToString(), context); });

            RuleFor(x => x.BankAccountNumber)
                .NotEmpty().WithMessage("Bank account is requierd.")
                .Must(IsValidBankAccountNumber)
                .WithMessage("Bank account number is not valid.");

        }

        private bool IsValidDate(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            return DateTime.TryParse(value, out _);
        }

        public static void IsValidPhoneNumber(ulong phoneNumber, string coutryCode, ValidationContext<UpdateCustomerDTO> context)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            try
            {
                var parsedPhoneNumber = phoneNumberUtil.Parse(phoneNumber.ToString(), coutryCode);

                if (!phoneNumberUtil.IsValidNumber(parsedPhoneNumber))
                    context.AddFailure("PhoneNumber", "Phone number is invalid.");
            }
            catch (NumberParseException)
            {
                context.AddFailure("PhoneNumber", "exception");
            }
        }

        public static bool IsValidBankAccountNumber(string bankAccountNumber)
        {
            if (string.IsNullOrWhiteSpace(bankAccountNumber))
                return false;
            string strRegex = @"^[0-9]{9,18}$";
            return Regex.IsMatch(bankAccountNumber, strRegex);
        }
    }
}
