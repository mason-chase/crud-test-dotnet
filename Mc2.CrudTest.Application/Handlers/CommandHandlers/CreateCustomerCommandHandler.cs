using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using ClassLibrary1Mc2.CrudTest.Domain.Entities;
using com.google.i18n.phonenumbers;
using java.lang;
using libphonenumber;
using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Common.Helpers;
using Mc2.CrudTest.Application.Common.Interfaces;
using MediatR;
using PhoneNumberUtil = com.google.i18n.phonenumbers.PhoneNumberUtil;

namespace Mc2.CrudTest.Application.Handlers.CommandHandlers;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, long>
{
    private readonly ICustomersRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomersRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<long> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {

        if (!ValidationHelper.IsValidPhoneNumber(request.PhoneNumber.ToString()))
        {
            throw new ValidationException("Invalid phone number.");
        }

        if (!ValidationHelper.IsValidEmail(request.Email))
        {
            throw new ValidationException("Invalid email address.");
        }

        if (!ValidationHelper.IsValidBankAccountNumber(request.BankAccountNumber))
        {
            throw new ValidationException("Invalid bank account number.");
        }
        
        var customer = new Customer()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            BankAccountNumber = request.BankAccountNumber
        };

        await _customerRepository.AddCustomerAsync(customer);

        return customer.Id;
    }
}