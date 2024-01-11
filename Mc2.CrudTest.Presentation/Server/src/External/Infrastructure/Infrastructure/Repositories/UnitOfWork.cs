using Domain.Abstractions;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;
    public ICustomerRepository CustomerRepository { get; private set; }
    public async Task SaveChangeAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync();
    }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context; 
        CustomerRepository = new CustomerRepository(_context);
       
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}