using Mc2.CrudTest.Presentation.Server.Core.Repository;
using Mc2.CrudTest.Presentation.Server.Core.Server;
using Mc2.CrudTest.Presentation.Server.Data;
using Mc2.CrudTest.Presentation.Server.Filters;
using Mc2.CrudTest.Presentation.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
		//injected by constructor in app.prgram
		DbContext dbContext;
		private CustomerQueryRepository customeQuery;
		CustomerCommandRepository customeCmdQuery;
		CustomerEventCommandRepository customerEventCommandRepository;

		private readonly ILogger<CustomerController> _logger;

        
		public CustomerController(ILogger<CustomerController> logger, IServiceProvider serviceProvider)
		{
			_logger = logger;
			dbContext = serviceProvider.GetService<InMemoryDBContext>();
			customeQuery = new CustomerQueryRepository(dbContext);
			customeCmdQuery = new CustomerCommandRepository(dbContext);
			customerEventCommandRepository = new CustomerEventCommandRepository(dbContext);
		}

		[HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
			List<Customer> customerList = await customeQuery.GetAllCustomers();

			return Ok(customerList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
			if (id > 0)
			{
				List<Customer> customerList = await customeQuery.GetCustomer(id);

				return Ok(customerList);
			}
            return new NotFoundResult();

        }

        [HttpPut]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            try
            {
                CustomerDao customerDao = (CustomerDao)customer.ExtractModelObject();
				await customeCmdQuery.AddCustomer(customerDao);
				await customerEventCommandRepository.AddCustomerEvent(customerDao);
				return Ok();
			}
            catch(Exception ex)
            {
                return new ServerErrorResult(ex.Message);
            }
            

        }

		[HttpPost]
		public async Task<IActionResult> UpdateCustomer(Customer customer)
		{
			try
			{
				await customeCmdQuery.UpdateCustomer((CustomerDao)customer.ExtractModelObject());
				return Ok();
			}
			catch (Exception ex)
			{
				return new ServerErrorResult(ex.Message);
			}
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(long id)
        {
            await customeCmdQuery.DeleteCustomer(id);
            return Ok();
        }
    }
}