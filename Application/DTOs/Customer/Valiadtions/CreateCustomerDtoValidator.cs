using Application.Common.Interfaces.Repositories;
using Application.DTOs.Customer.Entities;
using FluentValidation;

namespace Application.DTOs.Customer.Validations;

public class CreateCustomerDtoValidator : AbstractValidator<CreateCustomerDto>
{
    private readonly ICustomerRepository _customerRepository;
    public CreateCustomerDtoValidator(ICustomerRepository customerRepository)
    {
        _customerRepository= customerRepository;


        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("The first name is required.")
            .MaximumLength(50).WithMessage("maximum length can be 50 characters.");

        RuleFor(x => x.LastName)
           .NotEmpty().WithMessage("The last name is required.")
           .MaximumLength(50).WithMessage("maximum length can be 50 characters.");

        RuleFor(x => x.DateOfBirth)
         .NotEmpty().WithMessage("The birthday is required.");

        RuleFor(x => new { x.FirstName, x.LastName, x.DateOfBirth })
        .MustAsync(async (o, x, token) =>
        {
            return await _customerRepository.IsCustomerUnique(x.FirstName, x.LastName, x.DateOfBirth);
        }).WithMessage("The customer infoes is repetitive.");

        RuleFor(x => x.Email)
          .NotEmpty().WithMessage("The Email address is required.")
          .MaximumLength(100).WithMessage("maximum length can be 100 characters.")
          .EmailAddress().WithMessage("The Email address is not valid.")
          .MustAsync(async (o, Email, token) =>
          {
              return await _customerRepository.IsEmailUnique(Email);
          }).WithMessage("The email address is repetitive.");


        RuleFor(x => x.BankAccountNumber)
            .NotEmpty().WithMessage("The BankAccountNumber is required.")
            .MaximumLength(100).WithMessage("maximum length can be 100 characters.")
            .Matches(@"^[0-9]{9,18}$").WithMessage("Bank account number can be just number and the length is between 9 to 18.");
    }
}