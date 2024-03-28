using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet("Get")]
    public async Task<IActionResult> GetCustomers()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet("Get/{customerId}")]
    public async Task<IActionResult> GetCustomerById(int customerId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPost("create")]
    public async Task<IActionResult> CreateCustomer()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPut("update")]
    public async Task<IActionResult> UpdateCustomer()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    [HttpDelete("remove")]
    public async Task<IActionResult> RemoveCustomer()
    {
        throw new NotSupportedException();
    }
}