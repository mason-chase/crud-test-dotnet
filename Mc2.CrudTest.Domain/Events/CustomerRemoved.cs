using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Shared.Abstraction.Domain;
namespace Mc2.CrudTest.Domain.Events
{
    public record CustomerRemoved(Customer Customer) : IDomainEvent;
}
