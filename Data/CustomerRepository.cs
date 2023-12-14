using webapi.Models;

namespace webapi.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerDbContext _customerDbContext;

        public CustomerRepository(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        public List<Customer> GetCustomers()
        {
            return _customerDbContext.customers.ToList();
        }

        public Customer GetCustomer(int customerId)
        {
            return _customerDbContext.customers.Where(c => c.Id == customerId).ToList()[0];
        }

        public async Task<int> AddCustomer(Customer customer)
        {
            await _customerDbContext.AddAsync(customer);
            return await _customerDbContext.SaveChangesAsync();
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            var result = _customerDbContext.customers
                .Where(c => c.Id == customer.Id).ToList()[0];

            if (result != null)
            {
                result.Firstname = customer.Firstname;
                result.Lastname = customer.Lastname;
                result.Email = customer.Email;
                result.DateOfBirth = customer.DateOfBirth;
                result.PhoneNumber = customer.PhoneNumber;
                result.BankAccountNumber = customer.BankAccountNumber;

                await _customerDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<int> DeleteCustomer(int customerId)
        {
            var customer = _customerDbContext.customers.Where(c => c.Id == customerId).ToList()[0];
            _customerDbContext.customers.Remove(customer);
            return await _customerDbContext.SaveChangesAsync();
        }
    }
}