using Microsoft.AspNetCore.Mvc;
using webapi.Application;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private CustomersService customersService;

        public CustomersController(CustomerDbContext customerDbContext)
        {
            customersService = new CustomersService(customerDbContext);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Customer customer)
        {
            int retval = await customersService.AddCustomer(customer);
            if (retval == 1)
                return Created("custormers/id", customer.Id);
            else
                return BadRequest();
        }

        [HttpGet]
        public List<Customer> GetList()
        {
            return customersService.GetCustomers();
        }

        [HttpGet("{Id}")]
        public Customer GetCustomer(int Id)
        {
            return customersService.GetCustomer(Id);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, [FromBody] Customer customer)
        {
            var retval = await customersService.UpdateCustomer(customer);
            if (retval == 1)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCustomer(int Id)
        {
            var retval = await customersService.DeleteCustomer(Id);
            if (retval == 1)
                return Ok();
            else
                return BadRequest();
        }
    }
}