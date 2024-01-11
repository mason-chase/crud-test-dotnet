using Mc2.CrudTest.Application.Contract.Customers.Mappers;
using Mc2.CrudTest.Application.Contract.Customers.Responses;
using Mc2.CrudTest.Domain.Customers.Entities.Read;

namespace Mc2.CrudTest.Application.Customers.Mappers;

internal class GetCustomerByIdMapper : IGetCustomerByIdMapper
{
    public GetCustomerByIdResponse Map(Customer customer)
    {
        return new()
        {
            Id = customer.Id,
            Firstname = customer.Firstname,
            Lastname = customer.Lastname,
            DateOfBirth = customer.DateOfBirth,
            PhoneNumber = customer.PhoneNumber,
            Email = customer.Email,
            BankAccountNumber = customer.BankAccountNumber,
            Fullname = customer.Fullname,
        };
    }
}
