
using Mc2.CrudTest.Framework.Domain.Events;

namespace Mc2.CrudTest.Core.Domain.Customers.Events
{
    public class CustomerCreatedEvent : IEvent
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
