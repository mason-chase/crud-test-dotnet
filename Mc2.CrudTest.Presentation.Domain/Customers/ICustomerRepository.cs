namespace Mc2.CrudTest.Presentation.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task CreateCustomer(Customer customer);
    }
}
