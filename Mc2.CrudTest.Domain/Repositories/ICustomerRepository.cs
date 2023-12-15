using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task Add(Customer customer);
        Task Edit(Customer customer);
        Task Remove(Customer customer);
        Task<Customer> Take(CustomerId id);
    }
}
