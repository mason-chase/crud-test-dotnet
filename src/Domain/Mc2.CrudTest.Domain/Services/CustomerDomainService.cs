using Mc2.CrudTest.Domain.Models.Customers;

namespace Mc2.CrudTest.Domain.Services;

public class CustomerDomainService(ICustomerRepository customerRepository) : ICustomerDomainService
{
    public bool EmailIsUnique(string email) => 
        customerRepository.EmailIsUnique(email);
}