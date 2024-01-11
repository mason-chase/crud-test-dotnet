using Mc2.CrudTest.Application.Contract.Customers.Responses;
using Mc2.CrudTest.Domain.Customers.Entities.Read;

namespace Mc2.CrudTest.Application.Contract.Customers.Mappers;

public interface IGetCustomerByIdMapper
{
    GetCustomerByIdResponse Map(Customer customer);
}
