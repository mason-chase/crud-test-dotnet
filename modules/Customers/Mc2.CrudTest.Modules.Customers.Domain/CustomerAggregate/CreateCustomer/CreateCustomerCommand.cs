using Mc2.CrudTest.Modules.Customers.Domain.Models;
using Mc2.CrudTest.Shared.BuildingBlocks.CQRS;

namespace Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.CreateCustomer;

public record CreateCustomerCommand(Name FirstName, Name LastName, DateOnly DateOfBirth, Phone Phone, Email Email, BankAccountNumber BankAccountNumber)
    : ICommand<CustomerId>;