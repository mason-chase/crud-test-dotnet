using Mc2.Framework.Domain;

namespace Mc2.CrudTest.Domain.Models.Customers;

public interface ICustomerRepository : IRepository
{
    bool EmailIsUnique(string email);
}