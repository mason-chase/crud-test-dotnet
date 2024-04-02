using Application.DTOs.Customer.Entities;
using Domain.Entities;

namespace Application.Common.Interfaces.Repositories;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<bool> IsEmailUnique(string email);

    Task<bool> IsCustomerUnique(string firstName, string lastName, DateTime dayOfBirth);

    Task<bool> IsEmailUnique(int id,string email);

    Task<bool> IsCustomerUnique(int id,string firstName, string lastName, DateTime dayOfBirth);
    Task<List<Customer>> Search(CustomerSearchDto customerSearchDto);

}
