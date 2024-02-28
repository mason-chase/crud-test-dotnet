using Mc2.CrudTest.Domain.Entities;
using System.Linq.Expressions;

namespace Mc2.CrudTest.Domain.Repositories;

public interface ICustomerRepository
{
    Task<Customer?> GetAsync(long id, CancellationToken cancellationToken);
    Task<Customer?> GetAsync(Expression<Func<Customer, bool>> predicate, CancellationToken cancellationToken);
    Task AddAsync(Customer customer, CancellationToken cancellationToken);
    Task<IList<Customer>> GetAllAsync(CancellationToken cancellationToken);
    Task<IList<Customer>> GetAllAsync(Expression<Func<Customer, bool>> predicate, CancellationToken cancellationToken);
    Task DeleteAsync(long id, CancellationToken cancellationToken);
}
