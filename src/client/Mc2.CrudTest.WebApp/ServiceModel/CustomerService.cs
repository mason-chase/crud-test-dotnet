using Mc2.CrudTest.WebApp.ViewModels;

namespace Mc2.CrudTest.WebApp.ServiceModel;

public class CustomerService : ICustomerService
{
    private readonly HttpClient _httpClient;

    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private const string baseUrl = "";

    public async Task<List<Customer>> GetCustomers()
    {
        throw new NotImplementedException();
    }

    public async Task<Customer> GetCustomerById(int id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCustomer(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Task AddCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }
}