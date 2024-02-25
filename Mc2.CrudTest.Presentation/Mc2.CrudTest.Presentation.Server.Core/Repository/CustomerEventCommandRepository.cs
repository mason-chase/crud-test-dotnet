using Mc2.CrudTest.Presentation.Server.Data;
using Mc2.CrudTest.Presentation.Server.DataAccess;
using Mc2.CrudTest.Presentation.Server.DataAccess.Dao;
using Mc2.CrudTest.Presentation.Shared;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json;

namespace Mc2.CrudTest.Presentation.Server.Core.Repository
{
    public class CustomerEventCommandRepository : BaseAsyncRepository<CustomerEventEntity>
	{
		
		public CustomerEventCommandRepository(DbContext dbContext) : base(dbContext)
		{

		}
		public async Task AddCustomerEvent(CustomerDao customer)
		{
			await AddAsync(new CustomerEventEntity
			{ CustomerData = JsonSerializer.Serialize(customer), Status = Status.Enable, CustomerEventType = CustomerEventType.Add, CustomerId= customer.Id }

			, new CancellationToken(false));

		}
		
	}
}
