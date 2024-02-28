using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mc2.CrudTest.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly DataContext _dataContext;

    public CustomerRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
        dataContext.Database.EnsureCreated();
    }

    public async Task AddAsync(Customer customer, CancellationToken cancellationToken)
    {
        await _dataContext.Customers.AddAsync(customer, cancellationToken);
    }

    public async Task DeleteAsync(long id, CancellationToken cancellationToken)
    {
        var toDelete = await GetAsync(id, cancellationToken);

        if (toDelete is not null)
        {
            _dataContext.Customers.Remove(toDelete);
        }
    }

    public async Task<IList<Customer>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dataContext.Customers.ToListAsync(cancellationToken);

    }

    public async Task<IList<Customer>> GetAllAsync(Expression<Func<Customer, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dataContext.Customers.Where(predicate).ToListAsync(cancellationToken);

    }

    public async Task<IList<Customer>> GetAllAsync(Expression<Func<bool, Customer>> predicate, CancellationToken cancellationToken)
    {
        return await _dataContext.Customers.ToListAsync(cancellationToken);
    }

    public async Task<Customer?> GetAsync(long id, CancellationToken cancellationToken)
    {
        return await GetAsync(p => p.Id == id, cancellationToken);
    }


    public async Task<Customer?> GetAsync(Expression<Func<Customer, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dataContext.Customers.FirstOrDefaultAsync(predicate, cancellationToken);
    }

}
