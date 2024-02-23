namespace Mc2.CrudTest.Presentation.Contracts.Customers;

public interface ICustomerAppService
{
    Task CreateCustomer(CustomerCommand command);
    Task DeleteCustomer(int customerId);
    Task<List<CustomerQuery>> GetCustomers();
    Task UpdateCustomer(int customerId, CustomerCommand command);
}
