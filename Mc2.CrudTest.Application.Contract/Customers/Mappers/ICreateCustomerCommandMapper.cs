using Mc2.CrudTest.Application.Contract.Customers.Commands;
using Mc2.CrudTest.Application.Contract.Customers.Responses;
using Mc2.CrudTest.Domain.Customers.Entities.Write;

namespace Mc2.CrudTest.Application.Contract.Customers.Mappers;

public interface ICreateCustomerCommandMapper
{
    Customer Map(CreateCustomerCommand command);
    CreatedCustomerResponse Map(Customer customer);
}
