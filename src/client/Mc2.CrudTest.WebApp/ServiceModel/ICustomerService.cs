using System.Net;
using Mc2.CrudTest.WebApp.ViewModels;

namespace Mc2.CrudTest.WebApp.ServiceModel;

public interface ICustomerService
{
    Task<List<Customer>> GetCustomers();
    Task<Customer> GetCustomerById(int customerId);
    Task<HttpStatusCode> AddCustomer(CustomerCreateInput input);
    Task<HttpStatusCode> UpdateCustomer(int customerId, CustomerUpdateInput input);
    Task<HttpStatusCode> DeleteCustomer(int customerId);
}