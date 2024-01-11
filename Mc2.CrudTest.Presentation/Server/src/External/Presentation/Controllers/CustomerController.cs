using Application.Customers.Commands.CreateCustomer;
using Application.Customers.Commands.DeleteCustomer;
using Application.Customers.Commands.UpdateCustomer;
using Application.Customers.Queries.GetAllCustomer;
using Application.Customers.Queries.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CustomerResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomers(CancellationToken cancellationToken)
        {
            var query = new GetAllCustomersQuery();
            var customers = await _mediator.Send(query, cancellationToken);


            return Ok(customers);
        }
        
        [HttpGet("{customerId:int}")]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomerById(int customerId,CancellationToken cancellationToken)
        {
            var query = new GetCustomerByIdQuery(customerId);
            var customer = await _mediator.Send(query,cancellationToken);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }


        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateCustomerCommand(request.Firstname, request.Lastname, request.DateOfBirth,
                request.PhoneNumber, request.Email, request.BankAccountNumber);
            var result= await _mediator.Send(command,cancellationToken);
            return Ok(result);
        }


        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateCustomerCommand(request.Id,request.Firstname, request.Lastname, request.DateOfBirth,
                request.PhoneNumber, request.Email, request.BankAccountNumber);
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{customerId:int}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCustomer(int customerId,
            CancellationToken cancellationToken)
        {
            var command = new DeleteCustomerCommand(customerId);
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }
}
