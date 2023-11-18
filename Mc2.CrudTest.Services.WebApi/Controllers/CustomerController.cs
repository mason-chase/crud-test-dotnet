using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
	Persistence.DatabaseContext Context { get; }
	
	public CustomerController(Persistence.DatabaseContext dbContext)
	{
		
		Context = dbContext;
	}

	[HttpGet]
	public IActionResult GetCustomers()
	{
		using var work = new Persistence.UnitOfWork(Context);
		var customers = work.Customers.GetAll();
		return Ok(customers);
	}

	[HttpGet("{id}")]
	public IActionResult GetCustomer(int id)
	{
		using var work = new Persistence.UnitOfWork(Context);
		var customer = work.Customers.Get(id);

		if (customer == null)
		{
			return NotFound();
		}

		return Ok(customer);
	}

	[HttpPost]
	public IActionResult CreateCustomer([FromBody] Domain.Customer customer)
	{
		using var work = new Persistence.UnitOfWork(Context);
		work.Customers.Add(customer);
		work.Complete();

		return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
	}

	[HttpPut("{id}")]
	public IActionResult UpdateCustomer(int id, [FromBody] Domain.Customer updatedCustomer)
	{
		using var work = new Persistence.UnitOfWork(Context);
		var existingCustomer = work.Customers.Get(id);

		if (existingCustomer == null)
		{
			return NotFound();
		}

		existingCustomer.Firstname = updatedCustomer.Firstname;
		existingCustomer.Lastname = updatedCustomer.Lastname;
		existingCustomer.DateOfBirth = updatedCustomer.DateOfBirth;
		existingCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
		existingCustomer.Email = updatedCustomer.Email;
		existingCustomer.BankAccountNumber = updatedCustomer.BankAccountNumber;

		work.Complete();

		return NoContent();
	}

	[HttpDelete("{id}")]
	public IActionResult DeleteCustomer(int id)
	{
		using var work = new Persistence.UnitOfWork(Context);
		var customer = work.Customers.Get(id);

		if (customer == null)
		{
			return NotFound();
		}

		work.Customers.Remove(customer);
		work.Complete();

		return NoContent();
	}
}
