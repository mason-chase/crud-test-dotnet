using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Presentation.Server.Requests.Customers;
using Mc2.CrudTest.SharedKernel.WebApi;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.UseCases.Customers.Add
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : CustomController
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Add([FromBody] CustomerAddRequest request, CancellationToken cancellationToken)
        {
            var command = new CustomerAddCommand(request.FirstName, request.LastName, request.PhoneNumber, request.Email, request.DateOfBirth, request.BankAccount);
            var result = await _mediator.Send(command, cancellationToken);

            result.Uri = result.Id?.ToString() ?? " ";
            return FromServiceResult(result);
        }
    }
}
