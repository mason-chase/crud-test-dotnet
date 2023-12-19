using System.ComponentModel.DataAnnotations;
using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers;


[ApiController]
[Route("api/customers")]
public class CustomersController : ControllerBase
{

    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(nameof(CreateCustomer))]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
    {
        try
        {
            var customerId = await _mediator.Send(command);
            return Ok(customerId);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost(nameof(UpdateCustomer))]
    public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand command)
    {
        try
        {
            var customerId = await _mediator.Send(command);
            return Ok(customerId);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost(nameof(RemoveCustomer))]
    public async Task<IActionResult> RemoveCustomer([FromBody] RemoveCustomerCommand command)
    {
        try
        {
            var customerId = await _mediator.Send(command);
            return Ok(customerId);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet(nameof(GetCustomerById))]
    public async Task<IActionResult> GetCustomerById([FromQuery] long id)
    {
        return Ok(await _mediator.Send(new GetCustomerByIdQuery(){Id = id}));
    }
    [HttpGet(nameof(GetCustomerByPhone))]
    public async Task<IActionResult> GetCustomerByPhone([FromQuery]string phone)
    {
        return Ok(await _mediator.Send(new GetCustomerByPhoneQuery(){PhoneNumber = phone}));
    }
}
