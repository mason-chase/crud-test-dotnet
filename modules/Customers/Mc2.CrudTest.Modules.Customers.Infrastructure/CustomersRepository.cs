using System.Linq.Expressions;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate;
using Mc2.CrudTest.Modules.Customers.Domain.Models;
using Mc2.CrudTest.Shared.BuildingBlocks.Stores;
using Mc2.CrudTest.Shared.DataStore;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Modules.Customers.Infrastructure;

internal class CustomersRepository : IRepository<Customer, CustomerId>
{
    private readonly AppDbContext _context;
    private readonly DbSet<Customer> _entitySet;

    public CustomersRepository(AppDbContext context)
    {
        _context = context;
        _entitySet = _context.Set<Customer>();
    }

    public Task<Customer?> SingleOrDefaultAsync(Expression<Func<Customer, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return _context.Customers.SingleOrDefaultAsync(predicate, cancellationToken);
    }

    public Task<bool> AnyAsync(Expression<Func<Customer, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return _context.Customers.AnyAsync(predicate, cancellationToken);
    }

    public Task<Customer?> FirstOrDefaultAsync(Expression<Func<Customer, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return _context.Customers.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public void Add(Customer entity)
    {
        _entitySet.Add(entity);
    }

    public void Update(Customer entity)
    {
        _entitySet.Update(entity);
    }

    public void Remove(Customer entity)
    {
        _entitySet.Remove(entity);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}