using Ardalis.Result;
using Mc2.CrudTest.Application.Contract.Customers.Commands;
using Mc2.CrudTest.Application.Contract.Customers.Queries;
using Mc2.CrudTest.Application.Contract.Customers.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Endpoint.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<Result<CreatedCustomerResponse>> Create([FromBody] CreateCustomerCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut]
    public async Task<Result> Update([FromBody] UpdateCustomerCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpDelete("{Id:guid}")]
    public async Task<Result> Delete([FromRoute] DeleteCustomerCommand command)
    {
         return await _mediator.Send(command);
    }

    [HttpGet("{Id:guid}")]
    public async Task<Result<GetCustomerByIdResponse>> Get([FromRoute] GetCustomerByIdQuery query)
    {
        return await _mediator.Send(query);
    }
}
