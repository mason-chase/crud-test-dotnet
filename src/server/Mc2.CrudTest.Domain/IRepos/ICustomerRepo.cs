using Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Domain.IRepos;

public interface ICustomerRepo
{
    Task<Customer> GetById(int id);
    Task<IEnumerable<Customer>> GetAll();
    Task Add(Customer customer);
    Task Update(Customer customer);
    Task Delete(int id);
}