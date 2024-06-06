using Hamideh.Crud.Test.Application.CustomerFeatures.Command.AddCustomer;
using Hamideh.Crud.Test.Application.CustomerFeatures.Command.DeleteCustomer;
using Hamideh.Crud.Test.Application.CustomerFeatures.Queries.FindCustomerById;
using Hamideh.Crud.Test.Application.CustomerFeatures.Queries.GetCustomerList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hamideh.Crud.Test.Apis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {


        private readonly IMediator _mediator;


        public CustomerController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Create(AddCustomerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetCustomerListQuery()));
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetCustomerByIdQuery { Id = id }));
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteCustomerCommand { Id = id }));
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, EditCustomerCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }
    }
}
