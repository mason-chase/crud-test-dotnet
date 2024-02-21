using Mc2.CrudTest.Presentation.Contracts.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerAppService customerAppService)
        {
            _logger = logger;
            _customerAppService = customerAppService;
        }

        [HttpPost("customers/{id}")]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command)
        {
            await _customerAppService.CreateCustomer(command);
            return Ok();
        }
    }
}
