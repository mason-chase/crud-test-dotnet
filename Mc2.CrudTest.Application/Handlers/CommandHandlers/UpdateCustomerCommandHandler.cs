using System.ComponentModel.DataAnnotations;
using ClassLibrary1Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Common.Helpers;
using Mc2.CrudTest.Application.Common.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Application.Handlers.CommandHandlers;

public class UpdateCustomerCommandHandler: IRequestHandler<UpdateCustomerCommand, bool>
{
    private readonly ICustomersRepository _customerRepository;

    public UpdateCustomerCommandHandler(ICustomersRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

   public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
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
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            BankAccountNumber = request.BankAccountNumber
        };


        return await _customerRepository.UpdateCustomerAsync(customer);
    }
}