using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using webapi.Data;
using webapi.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private CustomerDbContext _customerDbContext;

        public CustomerController(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        [HttpPost]
        public async Task<Customer> Save([FromBody] Customer customer)
        {
            Console.WriteLine(customer.description);
            await _customerDbContext.AddAsync(customer);
            var retval = await _customerDbContext.SaveChangesAsync();
            Console.WriteLine(">>>>" + retval);
            return customer;
        }
    }
}