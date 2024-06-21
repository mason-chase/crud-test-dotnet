using Mc2.CrudTest.Modules.Customers.Domain.Models;
using Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;

namespace Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.CreateCustomer;

public record CustomerCreatedEvent(Name FirstName, Name LastName, DateOnly DateOfBirth, Phone PhoneNumber, Models.Email Email, BankAccountNumber BankAccountNumber)
    : IDomainEvent<CustomerId>;