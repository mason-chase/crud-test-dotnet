using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.EF.Repositories
{
    internal sealed class CustomerRepository : ICustomerRepository
    {
        private readonly DbSet<Customer> _customers;
        private readonly WriteDbContext _writeDbContext;

        public CustomerRepository(WriteDbContext writeDbContext)
        {
            _writeDbContext = writeDbContext;
            _customers = _writeDbContext.Customers;
        }
        public async Task Add(Customer customer)
        {
            await _customers.AddAsync(customer);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task Edit(Customer customer)
        {
            _customers.Update(customer);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task Remove(Customer customer)
        {
            _customers.Remove(customer);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task<Customer> Take(CustomerId id)
        {
            return await _customers.Where(c => c.Id == id).SingleOrDefaultAsync();
        }
    }
}
