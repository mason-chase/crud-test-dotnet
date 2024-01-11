using Mc2.CrudTest.Domain.Customers.Entities.Read;

namespace Mc2.CrudTest.Domain.Contract.Customers;

public interface ICustomerReadOnlyRepository : IReadOnlyRepository<Customer, Guid>
{
}
