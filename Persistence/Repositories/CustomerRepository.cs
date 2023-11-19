using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
	public CustomerRepository(DatabaseContext context)
			: base(context)
	{
	}

	public Customer? Find(string firstname, string lastname)
	{
		return
			Entities
			.SingleOrDefault
			(x => string.Compare(x.Firstname, firstname,true)==0 && 
			string.Compare(x.Lastname, lastname, true) == 0);
	}

	public async Task<Customer?> FindAsync(string firstname, string lastname)
	{
		return
			await
			Entities
			.SingleOrDefaultAsync
			(x => string.Compare(x.Firstname, firstname, true) == 0 &&
			string.Compare(x.Lastname, lastname, true) == 0);
	}
}
