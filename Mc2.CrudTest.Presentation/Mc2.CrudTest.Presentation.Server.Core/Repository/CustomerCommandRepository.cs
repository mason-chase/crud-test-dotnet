using Mc2.CrudTest.Presentation.Server.Data;
using Mc2.CrudTest.Presentation.Server.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Server.Core.Repository
{
    public class CustomerCommandRepository : BaseAsyncRepository<CustomerDao>
	{
		
		public CustomerCommandRepository(DbContext dbContext) : base(dbContext)
		{

		}
		public async Task AddCustomer(CustomerDao customer)
		{
			customer.Status = DataAccess.Status.Enable;

			//If we had a real database because of uniwue indexes these exception can be thrown by database and not needed to be handled here
			int similarEmails = Entities.Where(t => t.Email == customer.Email).Count();
			if (similarEmails > 0) throw new Exception("DuplicatedRecord- Email Duplicated");

			similarEmails = Entities.Where(t => t.FirstName == customer.FirstName && t.LastName == customer.LastName && t.BirthDate == customer.BirthDate).Count();
			if (similarEmails > 0) throw new Exception("DuplicatedRecord--FirstName & LatsName & BirthDate");

			await AddAsync(customer, new CancellationToken(false));
			
		}
		public async Task UpdateCustomer(CustomerDao customerDao)
		{
			//Todo---
			//Func<CustomerDao, string> func = x => x.FirstName;
			//await UpdateAsync(t => t.Id == customer.Id, sett=> sett.SetProperty(func, customer.FirstName), new CancellationToken(false));

			var customer = Entities.Where(t => t.Id == customerDao.Id).SingleOrDefault();
			customer.FirstName = customerDao.FirstName;
			customer.LastName = customerDao.LastName;
			customer.Email = customerDao.Email;
			customer.PhoneNumebr = customerDao.PhoneNumebr;
			customer.BirthDate = customerDao.BirthDate;
			customer.BankAccountNumber = customerDao.BankAccountNumber;
			Entities.Update(customer);
			dbContext.SaveChanges();

		}
		public async Task DeleteCustomer(long id)
		{
			//Inmemory has problem with execute update and dosent commit then i have to write 
			//	await DeleteAsync(t => t.Id == customer.Id, new CancellationToken(false));

			var customer = Entities.Where(t => t.Id == id).SingleOrDefault();
			customer.Status = Status.Deleted;
			Entities.Update(customer);
			dbContext.SaveChanges();

		}
	}
}
