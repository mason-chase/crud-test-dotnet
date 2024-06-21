using Mc2.CrudTest.Modules.Customers.Domain.Models;
using Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;
using Mc2.CrudTest.Shared.BuildingBlocks.CQRS;

namespace Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.DeleteCustomer;

public record DeleteCustomerCommand(CustomerId CustomerId)
    : ICommand;