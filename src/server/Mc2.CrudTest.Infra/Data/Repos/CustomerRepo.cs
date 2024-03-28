using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.IRepos;

namespace Mc2.CrudTest.Infra.Data.Repos;

public class CustomerRepo : ICustomerRepo
{
    public Task<Customer> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Add(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Task Update(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }
}