using Mc2.CrudTest.Application.Contract.Customers.Commands;
using Mc2.CrudTest.Application.Contract.Customers.Mappers;
using Mc2.CrudTest.Application.Contract.Customers.Responses;
using Mc2.CrudTest.Domain.Customers.Entities.Write;

namespace Mc2.CrudTest.Application.Customers.Mappers;

internal class CreateCustomerCommandMapper : ICreateCustomerCommandMapper
{
    public Customer Map(CreateCustomerCommand command)
    {
        return new(
            command.Firstname,
            command.Lastname,
            command.DateOfBirth,
            command.PhoneNumber,
            command.Email,
            command.BankAccountNumber);
    }

    public CreatedCustomerResponse Map(Customer customer)
    {
        return new()
        {
            Id = customer.Id,
            Firstname = customer.Firstname,
            Lastname = customer.Lastname,
            DateOfBirth = customer.DateOfBirth,
            PhoneNumber = customer.PhoneNumber,
            Email = customer.Email,
            BankAccountNumber = customer.BankAccountNumber
        };
    }
}
