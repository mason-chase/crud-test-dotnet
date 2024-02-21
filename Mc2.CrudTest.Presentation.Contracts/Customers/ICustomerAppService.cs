namespace Mc2.CrudTest.Presentation.Contracts.Customers;

public interface ICustomerAppService
{
    Task CreateCustomer(CreateCustomerCommand command);
}
