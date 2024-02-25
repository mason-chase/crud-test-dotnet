using Mc2.CrudTest.Presentation.Server.DataAccess.Dao;
using Mc2.CrudTest.Presentation.Shared;
using Microsoft.EntityFrameworkCore;


namespace Mc2.CrudTest.Presentation.Server.Core.Repository
{

    public class CustomerEventQueryRepository : BaseAsyncRepository<CustomerEventEntity>
	{
        public CustomerEventQueryRepository(DbContext dbContext) : base(dbContext)
		{

		}

        public async Task<List<CustomerEvent>> GetAllCustomerEvent(long customerId)
		{
			List<CustomerEventEntity> result = await ListAllAsync(t=>t.CustomerId == customerId, new CancellationToken(false));
			//return result;
           List<CustomerEvent> Fresult = new List<CustomerEvent>();
            foreach (var item in result)
            {
				var t = new CustomerEvent();
				t.LoadFromModel(item);
				Fresult.Add(t);
			}
			return Fresult;
		}

	}
}
