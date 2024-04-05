using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> FindById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> FindByEmail(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(_ => _.Email == email);
        }

        public async Task<Customer> FirstOrDefaultAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await _context.Customers.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public bool Add(Customer customer)
        {
            _context.Customers.Add(customer);
            var inserted = _context.SaveChanges();
            return inserted > 0;
        }

        public bool Update(Customer customer)
        {
            _context.Customers.Update(customer);
            var updated = _context.SaveChanges();
            return updated > 0;
        }

        public async Task<(bool, string)> Delete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                var removed = _context.SaveChanges();
                return removed > 0 ? (true, "Customer Deleted Successfully") : (false, "There was a problem with the delete operation!");
            }
            return (false, "Customer Not Found!");
        }
    }
}
