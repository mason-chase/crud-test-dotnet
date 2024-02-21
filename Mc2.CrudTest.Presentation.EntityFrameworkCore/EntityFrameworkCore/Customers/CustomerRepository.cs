using Mc2.CrudTest.Presentation.Domain.Customers;

namespace Mc2.CrudTest.Presentation.EntityFrameworkCore.EntityFrameworkCore.Customers;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerManagementDbContext _context;

    public CustomerRepository(CustomerManagementDbContext context)
    {
        _context = context;
    }

    public async Task CreateCustomer(Customer customer)
    {
        await _context.AddAsync(customer);
        await _context.SaveChangesAsync();
    }
}
