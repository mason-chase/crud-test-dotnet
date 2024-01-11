using Mc2.CrudTest.Domain.Customers.Entities.Write;

namespace Mc2.CrudTest.Domain.Contract.Customers;

public interface ICustomerWriteOnlyRepository : IWriteOnlyRepository<Customer, Guid>
{
    Task<bool> ExistsByEmailAsync(string email);
    Task<bool> ExistsByEmailAsync(string email, Guid customerId);
    Task<bool> ExistsByFullnameAndBirthdateAsync(string firstname, string lastname, DateTime birthdate);
    Task<bool> ExistsByFullnameAndBirthdateAsync(string firstname, string lastname, DateTime birthdate, Guid customerId);
}
