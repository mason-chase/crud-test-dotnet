using Application.Customers.Commands;
using Application.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            var id = await _mediator.Send(command);
            if (id > 0)
                return Ok(id);
            return BadRequest("There was a problem creating the customer");
        }

        [HttpPut]
        public async Task<IActionResult> Update(CreateCustomerCommand command)
        {
            var id = await _mediator.Send(command);
            if (id > 0)
                return Ok(id);
            return BadRequest("There was a problem creating the customer");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery { Id = id });
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery { Id = id });
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery { Id = id });
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
    }
}
