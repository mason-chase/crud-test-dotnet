using Mc2.CrudTest.Application.Commands.Customer;
using Mc2.CrudTest.Application.DTOs;
using Mc2.CrudTest.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator) => _mediator = mediator;

    /// <summary>
    /// Get All The Customers
    /// </summary>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet()]
    public async Task<IActionResult> GetCustomers(CancellationToken ct)
    {
        var query = new GetAllCustomerQuery();
        List<Customer> res = await _mediator.Send(query, ct);
        return Ok(res);
    }

    /// <summary>
    /// Get customer By CustomerId
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetCustomerById(int customerId, CancellationToken ct)
    {
        var query = new GetCustomerByIdQuery() { CustomerId = customerId };

        Customer res = await _mediator.Send(query, ct);

        return Ok(res);
    }


    /// <summary>
    /// Insert New Customer
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPost("create")]
    public async Task<IActionResult> CreateCustomer(CustomerCreateDTO dto, CancellationToken ct)
    {
        var command = new CreateCustomerCommand
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            DateOfBirth = dto.DateOfBirth,
            BankAccountNumber = dto.BankAccountNumber,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
        };

        await _mediator.Send(command, ct);

        return Created();
    }


    /// <summary>
    /// Update Already Added Customer
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="dto"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpPut("update/{customerId}")]
    public async Task<IActionResult> UpdateCustomer(int customerId, [FromBody] CustomerUpdateDTO dto, CancellationToken ct)
    {
        var command = new UpdateCustomerCommand
        {
            CustomerId = customerId,
            BankAccountNumber = dto.BankAccountNumber,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
        };
        await _mediator.Send(command, ct);
        return Ok();
    }

    /// <summary>
    /// Remove Customer
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    [HttpDelete("remove/{customerId}")]
    public async Task<IActionResult> RemoveCustomer(int customerId, CancellationToken ct)
    {
        var command = new RemoveCustomerCommand
        {
            CustomerId = customerId
        };
        await _mediator.Send(command, ct);

        return Ok();
    }
}