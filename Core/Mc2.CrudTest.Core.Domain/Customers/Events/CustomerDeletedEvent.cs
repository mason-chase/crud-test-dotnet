using Mc2.CrudTest.Framework.Domain.Events;

namespace Mc2.CrudTest.Core.Domain.Customers.Events
{
    public class CustomerDeletedEvent : IEvent
    {
        public Guid Id { get; set; }
    }
}
