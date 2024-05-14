using Mc2.CrudTest.Presentation.DomainServices;
using Mc2.CrudTest.Presentation.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : Controller
{
    private ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;

    }
    
    public async Task<Customer> GetCustomer(Guid id)
    {
        var customer = await  _customerService.GetCustomer(id);
        return customer;
    }

    public async Task CreateCustomer(Customer newCustomer)
    {
        await _customerService.CreateCustomerAsync(newCustomer);
    }

    public async Task UdateCustomer(Customer customer)
    {
        await _customerService.UpdateCustomerAsync(customer);
    }

    public async Task DeleteCustomer(Guid id)
    {
        await _customerService.DeleteCustomerAsync(id);
    }
}