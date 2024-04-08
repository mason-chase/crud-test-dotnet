using Application.DTOs.Customer;
using Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence
{
    public interface ICustomerService
    {
        Task<List<CustomerListDto>> GetAllCustomersAsync();

        Task<CustomerDetailDto> GetCustomerByIdAsync(Guid id);

        Task<Customer> CreateCustomerAsync(CustomerCreateUpdateDto customer);

        Task<Customer> UpdateCustomerAsync(Guid id, CustomerCreateUpdateDto updatedCustomer);

        Task<bool> DeleteCustomerAsync(Guid id);

        Task<bool> IsFirstNameLastNameDateOfBirthUnique(CustomerCreateUpdateDto customer, Guid? id);

        Task<bool> IsEmailUnique(CustomerCreateUpdateDto customer, Guid? id);
    }
}