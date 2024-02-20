using CrudTest.Data.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Services.Features.Marketing.Customers.CreateCustomer
{
    public class CreateCustomerCommandValidator: AbstractValidator<CreateCustomerCommand>
    {
        private readonly MarketingDbContext _context;

        public CreateCustomerCommandValidator(MarketingDbContext context)
        {


            _context = context;

            RuleFor(x => x.PhoneNumber).GreaterThanOrEqualTo(100u);

            RuleFor(x => x.FirstName)
                .MustAsync(BeUniqueFirstName)
                .WithMessage("Duplicate First Name");

            RuleFor(x => x.LastName)
                .MustAsync(BeUniqueLastName)
                .WithMessage("Duplicate Last Name");

            RuleFor(x=>x.Email)
                .NotEmpty().WithMessage("Email address is required")
                     .EmailAddress().WithMessage("A valid email is required");

            RuleFor(x => x.Email)
                .MustAsync(BeUniqueEmail)
                .WithMessage("Duplicate Email");

            RuleFor(x => x.DateOfBirth)
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
                var result = await Task.Run(()=>phoneNumberUtil.IsPossibleNumber(arg1.ToString(), "IR"));

                
                return result;
            }
            catch
            {
                return false;
            }
        }

        private async Task<bool> BeUniqueDateOfBirth(DateOnly only, CancellationToken token)
        {
            return !(await _context.Customers.AnyAsync(x => x.DateOfBirth == only));
        }

        private async Task<bool> BeUniqueEmail(string arg1, CancellationToken token)
        {
            return !(await _context.Customers.AnyAsync(x => x.Email == arg1));
        }

        private async Task<bool> BeUniqueLastName(string arg1, CancellationToken token)
        {
            return !(await _context.Customers.AnyAsync(x => x.LastName == arg1));
        }

        private async Task<bool> BeUniqueFirstName(string arg1, CancellationToken token)
        {
            return !(await _context.Customers.AnyAsync(x => x.FirstName == arg1));
        }
    }
}
