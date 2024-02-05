using Application.Models;
using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> CreateAsync(Customer input);
        Task<Customer?> UpdateAsync(Customer input);
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetAsync(int id);
        Task DeleteAsync(Customer input);
        Task<Customer?> GetByEmailAsync(string email);
        Task<Customer?> GetAsync(string firstName, string lastName, DateTime birthDay);
    }
}
