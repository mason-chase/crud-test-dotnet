using Mc2.CrudTest.Presentation.Contracts.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController(ILogger<CustomerController> logger, ICustomerAppService customerAppService) : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger = logger;
        private readonly ICustomerAppService _customerAppService = customerAppService;


        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCommand command)
        {
            await _customerAppService.CreateCustomer(command);
            return Ok();
        }
        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerAppService.GetCustomers();
            return Ok(customers);
        }
        [HttpPut("customers/{customerId}")]
        public async Task<IActionResult> UpdateCustomer(int customerId, [FromBody] CustomerCommand command)
        {
            await _customerAppService.UpdateCustomer(customerId, command);
            return Ok();

        }
        [HttpDelete("customers/{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            await _customerAppService.DeleteCustomer(customerId);
            return Ok();
        }
    }
}
