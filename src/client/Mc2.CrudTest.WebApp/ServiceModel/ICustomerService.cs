using Mc2.CrudTest.WebApp.ViewModels;

namespace Mc2.CrudTest.WebApp.ServiceModel;

public interface ICustomerService
{
    Task<List<Customer>> GetCustomers();
    Task<Customer> GetCustomerById(int id);
    Task AddCustomer(Customer customer);
    Task UpdateCustomer(Customer customer);
    Task DeleteCustomer(int id);
}