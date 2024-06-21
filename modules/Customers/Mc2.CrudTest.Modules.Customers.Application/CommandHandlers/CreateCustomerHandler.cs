using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate;
using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.CreateCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.Exceptions;
using Mc2.CrudTest.Modules.Customers.Domain.Models;
using Mc2.CrudTest.Shared.BuildingBlocks.CQRS;
using Mc2.CrudTest.Shared.BuildingBlocks.Stores;

namespace Mc2.CrudTest.Modules.Customers.Application.CommandHandlers;

public class CreateCustomerHandler : ICommandHandler<CreateCustomerCommand, CustomerId>
{
    private readonly IEventStore _eventStore;
    private readonly IRepository<Customer, CustomerId> _repository;

    public CreateCustomerHandler(IRepository<Customer, CustomerId> repository, IEventStore eventStore)
    {
        _repository = repository;
        _eventStore = eventStore;
    }

    public async Task<CustomerId> Handle(CreateCustomerCommand command, CancellationToken cancellationToken = default)
    {
        if (await _repository.AnyAsync(e => e.Email == command.Email.Value, cancellationToken))
            throw new CustomerAlreadyExistsException(command.Email.Value);
        if (await _repository.AnyAsync(x => x.FirstName == command.FirstName.Value && x.LastName == command.LastName.Value && x.DateOfBirth == command.DateOfBirth.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc), cancellationToken))
            throw new CustomerAlreadyExistsException(command.FirstName.Value, command.LastName.Value, command.DateOfBirth);

        Customer aggregate = Customer.Create(new CustomerCreatedEvent(command.FirstName, command.LastName, command.DateOfBirth, command.Phone, command.Email, command.BankAccountNumber));

        _repository.Add(aggregate);

        await _repository.SaveChangesAsync(cancellationToken);
        _eventStore.Commit(aggregate.Id, aggregate.Events);
        aggregate.ClearEvents();
        return new CustomerId(aggregate.Id);
    }
}