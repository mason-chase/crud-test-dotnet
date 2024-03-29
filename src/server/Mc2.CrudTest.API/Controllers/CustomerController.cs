using Mc2.CrudTest.Application.UseCases.Customer;
using Mc2.CrudTest.Application.UseCases.Customer.Queries;
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
    /// <returns></returns>
    [HttpGet("Get")]
    public async Task<IActionResult> GetCustomers()
    {
        List<Customer> res = await _mediator.Send(new GetAllCustomerReq());

        if (res.Count > 0)
            return Ok(res);
        return NotFound();
    }

    /// <summary>
    /// Get customer By CustomerId
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet("GetById")]
    public async Task<IActionResult> GetCustomerById(GetCustomerByIdReq query)
    {
        Customer res = await _mediator.Send(new GetCustomerByIdReq { CustomerId = query.CustomerId });

        return Ok(res);
    }


    /// <summary>
    /// Insert New Customer
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("create")]
    public async Task<IActionResult> CreateCustomer(CreateCustomerReq command)
    {
        await _mediator.Send(new CreateCustomerReq
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            PhoneNumber = command.PhoneNumber,
            Email = command.Email,
            DateOfBirth = command.DateOfBirth,
            BankAccountNumber = command.BankAccountNumber
        });

        return Created();
    }


    /// <summary>
    /// Update Already Added Customer
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("update")]
    public async Task<IActionResult> UpdateCustomer(UpdateCustomerReq command)
    {
        Customer res = await _mediator.Send(new UpdateCustomerReq
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            PhoneNumber = command.PhoneNumber,
            Email = command.Email,
            DateOfBirth = command.DateOfBirth,
            BankAccountNumber = command.BankAccountNumber
        });

        return Ok(res);
    }

    /// <summary>
    /// Remove Customer
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpDelete("remove")]
    public async Task<IActionResult> RemoveCustomer(RemoveCustomerReq command)
    {
        await _mediator.Send(new RemoveCustomerReq
        {
            CustomerId = command.CustomerId,
        });

        return Ok();
    }
}