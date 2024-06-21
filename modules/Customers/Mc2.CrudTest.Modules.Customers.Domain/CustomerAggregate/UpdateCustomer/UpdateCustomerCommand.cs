using Mc2.CrudTest.Modules.Customers.Domain.Models;
using Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;
using Mc2.CrudTest.Shared.BuildingBlocks.CQRS;

namespace Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.UpdateCustomer;

public record UpdateCustomerCommand(CustomerId CustomerId, Name FirstName, Name LastName, DateOnly DateOfBirth, Phone Phone, Models.Email Email, BankAccountNumber BankAccountNumber)
    : ICommand;