
using Hamideh.Crud.Test.Infrastracture.Persistence.SqlContext;


namespace Hamideh.Crud.Test.Infrastracture.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;
        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<IImmutableList<Customer>> GetCustomerListAsync()
        {
            var customerList = await _context.Customers.ToListAsync();
            return customerList.ToImmutableList();
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id) => await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);


        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }

        public void EditCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();
        }
    }


}
