using System.Threading.Tasks;

namespace Domain.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
	public Domain.Customer? Find(string firstname, string lastname);

	public Task<Domain.Customer?> FindAsync(string firstname, string lastname);
}
