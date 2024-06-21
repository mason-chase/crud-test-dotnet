using Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;
using Mc2.CrudTest.Shared.BuildingBlocks.CQRS;

namespace Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.GetCustomer;

public record GetCustomerQuery(int CustomerId)
    : IQuery<CustomerDto>;