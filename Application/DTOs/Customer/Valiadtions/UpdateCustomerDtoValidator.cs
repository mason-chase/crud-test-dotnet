using Application.Common.Interfaces.Repositories;
using Application.DTOs.Customer.Entities;
using FluentValidation;
using PhoneNumbers;

namespace Application.DTOs.Customer.Validations;

public class UpdateCustomerDtoValidator : AbstractValidator<UpdateCustomerDto>
{
    private readonly ICustomerRepository _customerRepository;
    public UpdateCustomerDtoValidator(ICustomerRepository customerRepository)
    {
        _customerRepository= customerRepository;

        Include(new BaseDtoValidator());

        RuleFor(x => x.FirstName)
            .NotNull().WithMessage("Please enter your first name.")
            .MaximumLength(50).WithMessage("maximum length can be 50 characters.");

        RuleFor(x => x.LastName)
           .NotNull().WithMessage("Please enter your last name.")
           .MaximumLength(50).WithMessage("maximum length can be 50 characters.");

        RuleFor(x => x.DateOfBirth)
         .NotNull().WithMessage("Please enter your birthday.");

        RuleFor(x => new { x.FirstName, x.LastName, x.DateOfBirth })
            .MustAsync(async (o, x, token) =>
            {
                return await _customerRepository.IsCustomerUnique(o.Id,x.FirstName, x.LastName, x.DateOfBirth);
            }).WithMessage("The customer info is repetitive");

        RuleFor(x => x.Email)
          .NotNull().WithMessage("Please enter your Email.")
          .MaximumLength(100).WithMessage("maximum length can be 100 characters.")
          .EmailAddress().WithMessage("Please enter the right format for Email")
          .MustAsync(async (o, Email, token) =>
          {
              return await _customerRepository.IsEmailUnique(o.Id,Email);
          }).WithMessage("The email address is repetitive");


        RuleFor(x => x.BankAccountNumber)
            .NotNull().WithMessage("Please enter your bank account number.")
            .MaximumLength(100).WithMessage("maximum length can be 100 characters.")
            .Matches(@"^[0-9]{9,18}$").WithMessage("Bank account number can be just number and the length is between 9 to 18");

        RuleFor(x => x.PhoneNumber)
            .NotNull().WithMessage("The phoneNumber is required.")
             .Must((o, x) =>
             {
                 PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();

                 PhoneNumber phoneNumber = phoneUtil.Parse(x.ToString(), "IR");
                 if (phoneUtil.GetNumberType(phoneNumber) == PhoneNumberType.MOBILE)
                     return phoneUtil.IsValidNumber(phoneNumber);
                 else return false;
             }).WithMessage("The PhoneNumber is not valid.");
    }
}