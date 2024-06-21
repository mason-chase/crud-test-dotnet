using Mc2.CrudTest.Modules.Customers.Domain.Models;
using Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;

namespace Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.DeleteCustomer;

public record CustomerDeletedEvent : IDomainEvent<CustomerId>;