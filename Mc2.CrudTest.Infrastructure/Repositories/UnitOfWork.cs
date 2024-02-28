using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Infrastructure.EFCore;

namespace Mc2.CrudTest.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    private ICustomerRepository _customerRepository;

    public UnitOfWork(DataContext context)
    {
        _context = context;
        context.Database.EnsureCreated();

    }
    public ICustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(_context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

}
