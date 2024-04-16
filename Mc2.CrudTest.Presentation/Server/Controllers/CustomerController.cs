using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        // private readonly ICustomerAppService _customerAppService;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        ///[HttpPost("customers/{id}")]
        //public async Task<IActionResult> CreateCustomer()
        //{

        ///       }
    }
}
