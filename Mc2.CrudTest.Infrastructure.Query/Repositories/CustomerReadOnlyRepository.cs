using Mc2.CrudTest.Domain.Contract.Customers;
using Mc2.CrudTest.Domain.Customers.Entities.Read;
using Mc2.CrudTest.Infrastructure.Query.DbContexts;

namespace Mc2.CrudTest.Infrastructure.Query.Repositories;

internal class CustomerReadOnlyRepository : BaseReadOnlyRepository<Customer, Guid>, ICustomerReadOnlyRepository
{
    public CustomerReadOnlyRepository(ReadDbContext readDbContext) : base(readDbContext)
    {
    }
}
