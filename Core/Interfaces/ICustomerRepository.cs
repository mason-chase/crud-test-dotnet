using Core.Models;

namespace Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetById(int id);
        Task<List<Customer>> GetAll();
        Task Add(Customer customer);
        void Update(Customer customer);
        Task Delete(int id);
    }
}
