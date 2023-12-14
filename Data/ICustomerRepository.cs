using webapi.Models;

namespace webapi.Data
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(int customerId);
        Task<int> AddCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<int> DeleteCustomer(int customerId);
    }
}