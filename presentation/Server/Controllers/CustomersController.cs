using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.CreateCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.DeleteCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.GetCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.UpdateCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.Models;
using Mc2.CrudTest.Presentation.Server.ExceptionHandlers;
using Mc2.CrudTest.Presentation.Server.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Creates a new Customer
    /// </summary>
    /// <response code="201">The Customer was successfully created.</response>
    /// <response code="400">The given input entries are invalid.</response>
    [ProducesResponseType(typeof(CreateCustomerRequestedResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseFailed), StatusCodes.Status400BadRequest)]
    [HttpPost("index")]
    public async Task<IActionResult> Create(CreateCustomerRequested request, CancellationToken cancellationToken = default)
    {
        CreateCustomerCommand command = new CreateCustomerCommand(
            FirstName: Name.Create(request.FirstName),
            LastName: Name.Create(request.LastName),
            DateOfBirth: request.DateOfBirth,
            Phone: Phone.Create(request.PhoneNumber),
            Email: Email.Create(request.Email),
            BankAccountNumber: BankAccountNumber.Create(request.BankAccountNumber)
        );
        CustomerId customerId = await _mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return Created($"/api/customers/index?id={customerId}", new CreateCustomerRequestedResponse
        {
            CustomerId = customerId.Value
        });
    }

    /// <summary>
    /// Updates and existing Customer
    /// </summary>
    /// <response code="204">The Customer was successfully updated.</response>
    /// <response code="400">The given input entries are invalid.</response>
    /// <response code="404">The Customer was not found.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseFailed), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseFailed), StatusCodes.Status404NotFound)]
    [HttpPut("index")]
    public async Task<IActionResult> Update(UpdateCustomerRequested request, CancellationToken cancellationToken = default)
    {
        UpdateCustomerCommand command = new UpdateCustomerCommand(
            CustomerId: new CustomerId(request.CustomerId),
            FirstName: Name.Create(request.FirstName),
            LastName: Name.Create(request.LastName),
            DateOfBirth: request.DateOfBirth,
            Phone: Phone.Create(request.PhoneNumber),
            Email: Email.Create(request.Email),
            BankAccountNumber: BankAccountNumber.Create(request.BankAccountNumber)
        );
        await _mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return NoContent();
    }

    /// <summary>
    /// Deletes an existing Customer
    /// </summary>
    /// <response code="204">The Customer was successfully deleted.</response>
    /// <response code="400">The given input entries are invalid.</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseFailed), StatusCodes.Status404NotFound)]
    [HttpDelete("index")]
    public async Task<IActionResult> Delete([FromQuery(Name = "id")] int customerId, CancellationToken cancellationToken = default)
    {
        DeleteCustomerCommand command = new(new CustomerId(customerId));
        await _mediator.Send(command, cancellationToken).ConfigureAwait(false);
        return NoContent();
    }

    /// <summary>
    /// Returns a Customer
    /// </summary>
    /// <response code="200">The Customer was successfully returned.</response>
    /// <response code="404">The Customer was not found.</response>
    [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseFailed), StatusCodes.Status404NotFound)]
    [HttpGet("index")]
    public async Task<IActionResult> Get([FromQuery(Name = "id")] int customerId, CancellationToken cancellationToken = default)
    {
        GetCustomerQuery query = new(customerId);
        CustomerDto response = await _mediator.Send(query, cancellationToken).ConfigureAwait(false);
        return Ok(response);
    }
}