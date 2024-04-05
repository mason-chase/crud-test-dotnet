using Core.Interfaces;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerDbContext _context;
        public ICustomerRepository CustomerRepository { get; }

        public UnitOfWork(CustomerDbContext context, ICustomerRepository customerRepository)
        {
            _context = context;
            CustomerRepository = customerRepository;
        }


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
