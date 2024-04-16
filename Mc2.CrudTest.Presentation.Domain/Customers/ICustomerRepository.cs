namespace Mc2.CrudTest.Presentation.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task CreateCustomer(Customer customer);
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task Update(Customer customer);
        Task Delete(Customer customer);
    }
}
