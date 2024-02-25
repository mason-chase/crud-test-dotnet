using Mc2.CrudTest.Presentation.Server.Data;
using Mc2.CrudTest.Presentation.Server.DataAccess;
using Mc2.CrudTest.Presentation.Shared;
using Microsoft.EntityFrameworkCore;


namespace Mc2.CrudTest.Presentation.Server.Core.Repository
{

    public class CustomerQueryRepository :BaseAsyncRepository<CustomerDao>
	{
        public CustomerQueryRepository(DbContext dbContext) : base(dbContext)
		{

		}
		
		public async Task<List<Customer>> GetAllCustomers()
		{
			List<CustomerDao> result = await ListAllAsync(t=>t.Status == Status.Enable ,new CancellationToken(false));
           List<Customer> Fresult = new List<Customer>();
            foreach (var item in result)
            {
				var customer = new Customer();
                customer.LoadFromModel(item);
				Fresult.Add(customer);
			}
			return Fresult;
		}

        public async Task<List<Customer>> GetCustomer(int id)
        {
            List<CustomerDao> result = await ListAllAsync(t => t.Status == Status.Enable && t.Id== id, new CancellationToken(false));
            List<Customer> Fresult = new List<Customer>();
            foreach (var item in result)
            {
                var customer = new Customer();
                customer.LoadFromModel(item);
                Fresult.Add(customer);
            }
            return Fresult;
        }

    }
}
