using Core.Models;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> FindById(int id);
        Task<Customer> FindByEmail(string email);
        Task<List<Customer>> GetAll();
        bool Add(Customer customer);
        bool Update(Customer customer);
        Task<(bool, string)> Delete(int id);
        Task<Customer> FirstOrDefaultAsync(Expression<Func<Customer, bool>> predicate);
    }
}
