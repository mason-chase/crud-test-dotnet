

using Mc2.CrudTest.Presentation.Shared.Entities;

namespace Mc2.CrudTest.Presentation.DomainServices;

public interface ICustomerService
{
    public Task CreateCustomerAsync(Customer customer);
    public Task UpdateCustomerAsync(Customer customer);
    public Task DeleteCustomerAsync(Guid customerId);
    public Task<Customer> GetCustomer(Guid customerId);
}