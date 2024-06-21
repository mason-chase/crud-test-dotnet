using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.CreateCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.DeleteCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.UpdateCustomer;
using Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;

namespace Mc2.CrudTest.Modules.Customers.Domain.Models;

public record Customer : AggregateRoot<CustomerId>
{
    private Customer()
    {
    }

    public int Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public bool IsDeleted { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ulong PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }

    public static Customer Create(CustomerCreatedEvent customerCreatedEvent)
    {
        Customer aggregate = new();
        aggregate.AppendEvent(customerCreatedEvent);
        return aggregate;
    }

    protected override void OnAppend(IDomainEvent<CustomerId> @event)
    {
        switch (@event)
        {
            case CustomerCreatedEvent e:
            {
                FirstName = e.FirstName.Value;
                LastName = e.LastName.Value;
                DateOfBirth = e.DateOfBirth.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);
                PhoneNumber = e.PhoneNumber.Value;
                Email = e.Email.Value;
                BankAccountNumber = e.BankAccountNumber.Value;
                break;
            }
            case CustomerUpdatedEvent e:
            {
                FirstName = e.FirstName.Value;
                LastName = e.LastName.Value;
                DateOfBirth = e.DateOfBirth.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc);
                PhoneNumber = e.PhoneNumber.Value;
                Email = e.Email.Value;
                BankAccountNumber = e.BankAccountNumber.Value;
                break;
            }
            case CustomerDeletedEvent e:
            {
                IsDeleted = true;
                break;
            }
        }
    }
}