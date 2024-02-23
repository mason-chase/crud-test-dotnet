using Mc2.CrudTest.Presentation.Domain.Customers;
using Microsoft.EntityFrameworkCore;

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

    public async Task Delete(Customer customer)
    {
        _context.Remove(customer);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Customer>> GetAll()
    {
        return await _context.Customers.AsNoTracking().ToListAsync();
    }

    public async Task<Customer> GetById(int id)
    {
        return await _context.Customers.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task Update(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }
}

