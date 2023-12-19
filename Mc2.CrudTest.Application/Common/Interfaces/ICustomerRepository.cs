using ClassLibrary1Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Application.Common.Interfaces;

public interface ICustomersRepository
{
    Task<Customer?> GetCustomerByIdAsync(long customerId);
    Task<Customer?> GetCustomerByPhoneAsync(string phone);
    Task<long> AddCustomerAsync(Customer customer);
    Task<bool> UpdateCustomerAsync(Customer customer);
    Task<bool> RemoveCustomerAsync(long requestId);
}