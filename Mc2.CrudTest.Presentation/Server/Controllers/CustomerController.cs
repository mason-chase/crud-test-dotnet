using Mc2.CrudTest.Presentation.Application.Common.Models;
using Mc2.CrudTest.Presentation.Application.Customers.Commands.AddCustomer;
using Mc2.CrudTest.Presentation.Application.Customers.Commands.DeleteCustomer;
using Mc2.CrudTest.Presentation.Application.Customers.Commands.UpdateCustomer;
using Mc2.CrudTest.Presentation.Application.Customers.Queries.GetCustomerById;
using Mc2.CrudTest.Presentation.Application.Customers.Queries.GetCustomers;
using Mc2.CrudTest.Presentation.Application.Customers.Queries.IsExistCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var result = await _mediator.Send(new GetCustomersQuery());

                if (result.Succeeded)
                {
                    return Ok(result.Data);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetCustomerByIdQuery(id));

                if (result.Succeeded)
                {
                    return Ok(result.Data);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerModel customer)
        {
            try
            {
                var result = new Result();
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(x => x.Errors);

                    result.Status = ResultStatusEnum.InvalidValidation;
                    result.Errors.AddRange(errors.Select(error => new Error(error.ToString(), error.ErrorMessage)));

                    return BadRequest(result);
                }

                var isExistEmailResult = await _mediator.Send(new IsExistCustomerEmailQuery(customer.Email));

                if (isExistEmailResult.Data == true)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Email Already Exist!";
                    return BadRequest(result);
                }

                var isExistNameResult = await _mediator.Send(new IsExistCustomerNameQuery(customer.FirstName, customer.LastName, customer.DateOfBirth));

                if (isExistNameResult.Data == true)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The FirstName, LastName and Birth Date Already Exist!";
                    return BadRequest(result);
                }

                var addResult = await _mediator.Send(new AddCustomerCommand(customer));

                if (addResult.Succeeded)
                {
                    return Ok(addResult.Data);
                }
                else
                {
                    return BadRequest(addResult.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(CustomerModel customer)
        {
            try
            {
                var result = new Result();
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(x => x.Errors);

                    result.Status = ResultStatusEnum.InvalidValidation;
                    result.Errors.AddRange(errors.Select(error => new Error(error.ToString(), error.ErrorMessage)));

                    return BadRequest(result);
                }

                var isExistEmailResult = await _mediator.Send(new IsExistCustomerEmailForUpdateQuery(customer.Id, customer.Email));

                if (isExistEmailResult.Data == true)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Email Already Exist!";
                    return BadRequest(result);
                }

                var isExistNameResult = await _mediator.Send(new IsExistCustomerNameForUpdateQuery(customer.Id, customer.FirstName, customer.LastName, customer.DateOfBirth));

                if (isExistNameResult.Data == true)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The FirstName, LastName and Birth Date Already Exist!";
                    return BadRequest(result);
                }

                var updateResult = await _mediator.Send(new UpdateCustomerCommand(customer));

                if (updateResult.Succeeded)
                {
                    return Ok(updateResult.Data);
                }
                else
                {
                    return BadRequest(updateResult.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteCustomerCommand(id));

                if (result.Succeeded)
                {
                    return Ok(result.Succeeded);
                }
                else
                {
                    return BadRequest(result.Message);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}