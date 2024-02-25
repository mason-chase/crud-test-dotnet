using Mc2.CrudTest.Presentation.Server.Core.Repository;
using Mc2.CrudTest.Presentation.Server.Core.Server;
using Mc2.CrudTest.Presentation.Server.Data;
using Mc2.CrudTest.Presentation.Server.Filters;
using Mc2.CrudTest.Presentation.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerEventController : ControllerBase
    {
		DbContext dbContext;
		private CustomerEventQueryRepository customerEventQuery;


		private readonly ILogger<CustomerController> _logger;

        public CustomerEventController(ILogger<CustomerController> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
			dbContext = serviceProvider.GetService<InMemoryDBContext>();
			customerEventQuery = new CustomerEventQueryRepository(dbContext);

		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(long customerId = 1)
        {
            List<CustomerEvent> customerEventList = await customerEventQuery.GetAllCustomerEvent(customerId);
            return Ok(customerEventList);
        }

      
    }
}