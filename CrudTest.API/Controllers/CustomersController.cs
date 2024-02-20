using CrudTest.Models.Entities.Marketing.Customers;
using CrudTest.Services.Features.Marketing.Customers.CreateCustomer;
using CrudTest.Services.Features.Marketing.Customers.DeleteCustomer;
using CrudTest.Services.Features.Marketing.Customers.GetAllCustomers;
using CrudTest.Services.Features.Marketing.Customers.UpdateCustomer;
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
        public async Task<int> CreateCustomerAsync(CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);

            if(result == 1)
            {
                HttpContext.Response.StatusCode = 201;
            }

            return result;
        }

        [HttpGet("")]

        public async Task<GetAllCustomersResponse> GetCustomersAsync()
        {
            var result = await _mediator.Send(new GetAllCustomersQuery());

            return result;
        }

        [HttpDelete("{customerId}")]
        public async Task<DeleteCustomerResponse> DeleteCustomerAsync(Guid customerId)
        {
            var result = await _mediator.Send(new DeleteCustomerCommand(customerId));

            return result;
        }

        [HttpPut("{customerId}")]

        public async Task<UpdateCustomerResponse> UpdateCustomerAsync(Guid customerId,UpdateCustomerCommand command)
        {
            command.CustomerId = customerId;

            var result = await _mediator.Send(command);

            return result;
        }
    }
}
