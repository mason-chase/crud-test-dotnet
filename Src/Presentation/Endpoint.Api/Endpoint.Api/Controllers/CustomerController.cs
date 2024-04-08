using Application.Contracts.Application;
using Application.Contracts.Persistence;
using Application.DTOs.Customer;
using Domain.Entities.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IPhoneNumberService _phoneNumberService;

        public CustomerController(ICustomerService customerService,
            IPhoneNumberService phoneNumberService)
        {
            _customerService = customerService;
            _phoneNumberService = phoneNumberService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerListDto>>> Get()
        {
            var customers = await _customerService.GetAllCustomersAsync();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDetailDto>> Get(Guid id)
        {
            var customerDetailDto = await _customerService.GetCustomerByIdAsync(id);
            if (customerDetailDto is null)
                return NotFound();

            return Ok(customerDetailDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CustomerCreateUpdateDto customer)
        {
            if (await _customerService.IsFirstNameLastNameDateOfBirthUnique(customer, null) is false)
                return BadRequest("Customer with these first name and Last name and date of birth already exists!");

            if (await _customerService.IsEmailUnique(customer, null) is false)
                return BadRequest("Customer with this email already exists!");

            if (await _phoneNumberService.IsValid(customer.PhoneNumber.ToString()) is false)
                return BadRequest("Phone number is not correct");

            await _customerService.CreateCustomerAsync(customer);

            return Created();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, CustomerCreateUpdateDto updatedCustomer)
        {
            var existingCustomer = await _customerService.GetCustomerByIdAsync(id);
            if (existingCustomer is null)
                return NotFound();

            if (await _customerService.IsFirstNameLastNameDateOfBirthUnique(updatedCustomer, id) is false)
                return BadRequest("Customer with these first name and Last name and date of birth already exists!");

            if (await _customerService.IsEmailUnique(updatedCustomer, id) is false)
                return BadRequest("Customer with this email already exists!");

            if (await _phoneNumberService.IsValid(updatedCustomer.PhoneNumber.ToString()) is false)
                return BadRequest("Invalid mobile phone number.");

            await _customerService.UpdateCustomerAsync(id, updatedCustomer);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var customerToRemove = await _customerService.GetCustomerByIdAsync(id);
            if (customerToRemove is null)
                return NotFound();

            await _customerService.DeleteCustomerAsync(id);

            return NoContent();
        }
    }
}