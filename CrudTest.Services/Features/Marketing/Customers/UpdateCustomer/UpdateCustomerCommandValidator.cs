using CrudTest.Data.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Services.Features.Marketing.Customers.UpdateCustomer
{
    public class UpdateCustomerCommandValidator: AbstractValidator<UpdateCustomerCommand>
    {
        private readonly MarketingDbContext _context;

        public UpdateCustomerCommandValidator(MarketingDbContext context)
        {

            _context = context;
            

            RuleFor(x => x)
                .MustAsync(BeUniqueFirstName)
                .WithMessage("Duplicate First Name");

            RuleFor(x => x)
                .MustAsync(BeUniqueLastName)
                .WithMessage("Duplicate Last Name");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email address is required")
                     .EmailAddress().WithMessage("A valid email is required");

            RuleFor(x => x)
                .MustAsync(BeUniqueEmail)
                .WithMessage("Duplicate Email");

            RuleFor(x => x)
                .MustAsync(BeUniqueDateOfBirth)
                .WithMessage("Duplicate date of birth");

            RuleFor(x => x.PhoneNumber)
                .MustAsync(BeValidPhoneNumber)
                .WithMessage("Invalid phone number");

        }

        private async Task<bool> BeValidPhoneNumber(ulong arg1, CancellationToken token)
        {
            PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
            try
            {
                var result = await Task.Run(() => phoneNumberUtil.IsPossibleNumber(arg1.ToString(), "IR"));


                return result;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> BeUniqueDateOfBirth(UpdateCustomerCommand dto, CancellationToken token)
        {
            return !(await _context.Customers.AnyAsync(x => x.DateOfBirth == dto.DateOfBirth && x.Id != dto.CustomerId ));
        }

        private async Task<bool> BeUniqueEmail(UpdateCustomerCommand dto, CancellationToken token)
        {
            return !(await _context.Customers.AnyAsync(x => x.Email == dto.Email && x.Id != dto.CustomerId));
        }

        private async Task<bool> BeUniqueLastName(UpdateCustomerCommand dto, CancellationToken token)
        {
            return !(await _context.Customers.AnyAsync(x => x.LastName == dto.LastName && x.Id != dto.CustomerId));
        }

        private async Task<bool> BeUniqueFirstName(UpdateCustomerCommand dto, CancellationToken token)
        {
            return !(await _context.Customers.AnyAsync(x => x.FirstName == dto.FirstName && x.Id != dto.CustomerId));
        }
    }
    
}
