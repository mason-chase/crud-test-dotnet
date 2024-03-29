using System.Net;
using System.Net.Http.Json;
using Mc2.CrudTest.WebApp.ViewModels;

namespace Mc2.CrudTest.WebApp.ServiceModel;

public class CustomerService(HttpClient httpClient, IConfiguration configuration) : ICustomerService
{
    private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    private readonly IConfiguration _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));


    public async Task<List<Customer>> GetCustomers()
    {
        return (await _httpClient.GetFromJsonAsync<List<Customer>>("/api/customer"))!;
    }

    public async Task<Customer> GetCustomerById(int customerId)
    {
        return (await _httpClient.GetFromJsonAsync<Customer>($"api/customer/{customerId}"))!;
    }

    public async Task<HttpStatusCode> AddCustomer(CustomerCreateInput input)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/api/Customer/create", input);
        HttpStatusCode resCode = response.StatusCode;

        return response.StatusCode;
    }

    public async Task<HttpStatusCode> UpdateCustomer(int customerId, CustomerUpdateInput input)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/customer/update/{customerId}", input);
        response.EnsureSuccessStatusCode();
        return response.StatusCode;
    }

    public async Task<HttpStatusCode> DeleteCustomer(int customerId)
    {
        var response = await _httpClient.DeleteAsync($"api/customer/remove/{customerId}");
        return response.StatusCode;
    }
}