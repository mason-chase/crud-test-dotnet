using Mc2.CrudTest.Application.Features.Customer.Command.CreateCustomer;
using Mc2.CrudTest.Application.Features.Customer.Query.GetAllCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.API.Controllers;

[ApiController]
[Route("api/v1/customer")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("get-all")]
    public async Task<ActionResult<List<GetAllCustomersResponse>>> GetAllCustomer([FromQuery] GetAllCustomersRequest getAllCustomersRequest, CancellationToken cancellationToken)
    {
        var customerModelList = await _mediator.Send(getAllCustomersRequest, cancellationToken);
        return StatusCode(StatusCodes.Status200OK, customerModelList);
    }
    
    [HttpPost("create")]
    public async Task<ActionResult<CreateCustomerResponse>> Crete(CreateCustomerRequest createCustomerRequest, CancellationToken cancellationToken)
    {
        var createdCustomer = await _mediator.Send(createCustomerRequest, cancellationToken);
        return StatusCode(StatusCodes.Status201Created, createdCustomer);
    }

}