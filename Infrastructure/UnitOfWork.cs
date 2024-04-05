using Core.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerDbContext _context;
        private ICustomerRepository _customerRepository;

        public UnitOfWork(CustomerDbContext context)
        {
            _context = context;
        }

        public ICustomerRepository Customers => _customerRepository ??= new CustomerRepository(_context);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
