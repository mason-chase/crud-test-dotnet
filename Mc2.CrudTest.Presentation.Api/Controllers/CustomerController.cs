using FluentValidation;
using Mc2.CrudTest.Presentation.Application.Customers;
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
        private readonly IValidator<CreateCustomerCommand> _validator;

        public CustomerController(ILogger<CustomerController> logger, ICustomerAppService customerAppService, IValidator<CreateCustomerCommand> validator)
        {
            _logger = logger;
            _customerAppService = customerAppService;
            _validator = validator;
        }

        [HttpPost("customers")]
        public async Task<IActionResult> CreateCustomer([FromBody]CreateCustomerCommand command)
        {
            _validator.Validate(command);
            await _customerAppService.CreateCustomer(command);
            return Ok();
        }
    }
}
