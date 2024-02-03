using Application.Features.Customers.Commands.Add;
using Application.Features.Customers.Commands.Delete;
using Application.Features.Customers.Commands.Edit;
using Application.Features.Customers.Queries.GetAll;
using Application.Features.Customers.Queries.GetById;
using Application.Models;
using Domain.Entities;
using Mc2.CrudTest.Presentation.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    public class CustomerController : BaseApiController<CustomerController>
    {

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get All Customers
        /// </summary>
        /// <returns>Status 200 OK</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var resultBrands = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(await Result<List<Customer>>.SuccessAsync(resultBrands.Data.Customers));
        }

        /// <summary>
        /// Get a Customer By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 Ok</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var resultBrand = await _mediator.Send(new GetCustomerByIdQuery() { Id = id });
            return Ok(await Result<Customer>.SuccessAsync(resultBrand.Data.Customer));
        }

        /// <summary>
        /// Create a Customer
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerDTO input)
        {
            return Ok(await _mediator.Send(new AddCustomerCommand { Customer = input}));
        }

        /// <summary>
        /// Edit a Customer
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPut]
        public async Task<IActionResult> Edit(UpdateCustomerDTO input)
        {
            return Ok(await _mediator.Send(new EditCustomerCommand { Customer = input }));
        }

        /// <summary>
        /// Delete a Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteCustomerCommand { Id = id }));
        }


    }
}