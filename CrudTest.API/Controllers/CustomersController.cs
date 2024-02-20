using CrudTest.Services.Features.Marketing.Customers.CreateCustomer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<object> CreateCustomerAsync(CreateCustomerCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
