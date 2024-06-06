using Hamideh.Crud.Test.Domain.Entities;
using System.Collections.Immutable;

namespace Hamideh.Crud.Test.Domain
{
    public interface ICustomerRepository
    {
        Task AddCustomerAsync(Customer customer);
        void DeleteCustomer(Customer customer);
        void EditCustomer(Customer customer);
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<IImmutableList<Customer>> GetCustomerListAsync();
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}