namespace Domain.Repositories;

public interface IUnitOfWork : System.IDisposable
{
	ICustomerRepository Customers { get; }

	int Complete();
}
