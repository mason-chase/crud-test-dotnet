using Mc2.CrudTest.Application.Features.Customer.Command.CreateCustomer;
using Mc2.CrudTest.Application.Features.Customer.Command.DeleteCustomer;
using Mc2.CrudTest.Application.Features.Customer.Command.UpdateCustomer;
using Mc2.CrudTest.Application.Features.Customer.Query.GetAllCustomers;
using Mc2.CrudTest.Application.Features.Customer.Query.GetCustomerById;
using Mc2.CrudTest.Domain.Models;
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
    public async Task<ActionResult<List<CustomerModel>>> GetAllCustomer([FromQuery] GetAllCustomersRequest getAllCustomersRequest, CancellationToken cancellationToken)
    {
        List<CustomerModel> customerModelList = await _mediator.Send(getAllCustomersRequest, cancellationToken);
        return StatusCode(StatusCodes.Status200OK, customerModelList);
    }
    
    [HttpGet("get-by-id")]
    public async Task<ActionResult<CustomerModel>> GetAllCustomer([FromQuery] GetCustomerByIdRequest getCustomerByIdRequest, CancellationToken cancellationToken)
    {
        CustomerModel customerModel = await _mediator.Send(getCustomerByIdRequest, cancellationToken);
        return StatusCode(StatusCodes.Status200OK, customerModel);
    }
    
    [HttpPost("create")]
    public async Task<ActionResult<CustomerModel>> Crete(CreateCustomerRequest createCustomerRequest, CancellationToken cancellationToken)
    {
        CustomerModel createdCustomer = await _mediator.Send(createCustomerRequest, cancellationToken);
        return StatusCode(StatusCodes.Status201Created, createdCustomer);
    }
    
    [HttpDelete("update")]
    public async Task<ActionResult<CustomerModel>> Update([FromQuery] UpdateCustomerRequest updateCustomerRequest, CancellationToken cancellationToken)
    {
        CustomerModel updatedCustomer = await _mediator.Send(updateCustomerRequest, cancellationToken);
        return StatusCode(StatusCodes.Status200OK, updatedCustomer);
    }
    
    [HttpDelete("delete")]
    public async Task<ActionResult<CustomerModel>> Delete([FromQuery] DeleteCustomerRequest deleteCustomerRequest, CancellationToken cancellationToken)
    {
        CustomerModel deletedCustomer = await _mediator.Send(deleteCustomerRequest, cancellationToken);
        return StatusCode(StatusCodes.Status200OK, deletedCustomer);
    }

}