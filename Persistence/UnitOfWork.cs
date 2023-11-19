using Domain.Repositories;
using Persistence.Repositories;

namespace Persistence;

public class UnitOfWork : IUnitOfWork
{
	private readonly DatabaseContext _context;

	public UnitOfWork(DatabaseContext context)
	{
		_context = context;

		Customers = new CustomerRepository(_context);
	}

	public ICustomerRepository Customers { get; private set; }
	
	public int Complete()
	{
		return _context.SaveChanges();
	}

	public void Dispose()
	{
		_context.Dispose();
	}
}
