using Application.Commom.Models;
using Application.DTOs.Customer.Entities;
using Application.Entities.Customer.Requests.Commands;
using Application.Entities.Customer.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Apis.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> CreateCustomer([FromBody] CreateCustomerDto createCustomerDto)
        {
            var command = new CreateCustomerCommand { CreateCustomerDto = createCustomerDto };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer([FromBody] UpdateCustomerDto updateCustomerDto)
        {
            var command = new UpdateCustomerCommand { UpdateCustomerDto = updateCustomerDto };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var command = new DeleteCustomerCommand { Id = id };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        [HttpGet]
        public async Task<ActionResult<UpdateCustomerDto>> GetCustomer(int id)
        {
            var command = new GetCustomerQuery { Id = id };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        [HttpPost]
        public async Task<ActionResult<Result<List<CustomerListDto>>>> GetCustomers([FromBody] CustomerSearchDto customerSearchDto)
        {
            var command = new GetCustomersQuery() { CustomerSearchDto = customerSearchDto };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }
    }
}
