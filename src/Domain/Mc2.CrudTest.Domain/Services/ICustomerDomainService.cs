using Mc2.Framework.Domain.Events;

namespace Mc2.CrudTest.Domain.Services;

public interface ICustomerDomainService:IDomainService
{
    bool EmailIsUnique(string email);
}