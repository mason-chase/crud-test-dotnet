using Application.Interfaces.Repositories;
using Application.Models;
using FluentValidation;
using PhoneNumbers;
using System.Text.RegularExpressions;

namespace Application.Validators
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerDTO>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerValidator(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;


            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is requierd.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is requierd.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is requierd.")
                .EmailAddress().WithMessage("Email is not valid.")
                .Must(HaveUniqueEmail).WithMessage("Email already used.");

            RuleFor(x => x.DateOfBirth)
               .NotNull().WithMessage("Date of birth is requierd.");

            RuleFor(x => new { x.FirstName, x.LastName, x.DateOfBirth })
                .Must(x => HaveUnique_FirstName_LastName_BirthDay(x.FirstName, x.LastName, x.DateOfBirth))
                .WithMessage("there is a customer with same firstName, lastName and birthday.");

            RuleFor(x => new { x.PhoneNumber, x.Country })
                .NotEmpty().WithMessage("Phone number is requierd.")
                .Custom((x, context) => { IsValidPhoneNumber(x.PhoneNumber, x.Country.ToString(), context); });

            RuleFor(x => x.BankAccountNumber)
                .NotEmpty().WithMessage("Bank account is requierd.")
                .Must(IsValidBankAccountNumber)
                .WithMessage("Bank account number is not valid.");

        }


        public static void IsValidPhoneNumber(ulong phoneNumber, string coutryCode, ValidationContext<CreateCustomerDTO> context)
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


        private bool HaveUniqueEmail(string email)
        {
            return this._customerRepository.GetByEmailAsync(email).Result == null;
        }


        private bool HaveUnique_FirstName_LastName_BirthDay(string firstName, string lastName, DateTime birthDay)
        {
            return this._customerRepository.GetAsync(firstName, lastName, birthDay).Result == null;
        }

        public static bool IsValidBankAccountNumber(string bankAccountNumber)
        {
            if (string.IsNullOrWhiteSpace(bankAccountNumber))
                return false;
            string strRegex = @"IR\d{24}";
            return Regex.IsMatch(bankAccountNumber, strRegex);
        }
    }
}
