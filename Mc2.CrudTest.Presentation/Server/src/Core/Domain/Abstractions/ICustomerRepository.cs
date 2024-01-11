using Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace Domain.Abstractions;

public interface ICustomerRepository
{
    public Task<List<Customer>> GetAllAsync();
    public Task<Customer> GetByIdAsync(int id);
    public Task<bool> AddAsync(Customer customer);
    public Task<bool> UpdateAsync(Customer customer);
    public Task<bool> DeleteAsync(int id);
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}