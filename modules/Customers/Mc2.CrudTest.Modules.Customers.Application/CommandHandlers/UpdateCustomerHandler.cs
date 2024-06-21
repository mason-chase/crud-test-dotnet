using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.UpdateCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.Exceptions;
using Mc2.CrudTest.Modules.Customers.Domain.Models;
using Mc2.CrudTest.Shared.BuildingBlocks.CQRS;
using Mc2.CrudTest.Shared.BuildingBlocks.Stores;

namespace Mc2.CrudTest.Modules.Customers.Application.CommandHandlers;

public class UpdateCustomerHandler : ICommandHandler<UpdateCustomerCommand>
{
    private readonly IEventStore _eventStore;
    private readonly IRepository<Customer, CustomerId> _repository;

    public UpdateCustomerHandler(IRepository<Customer, CustomerId> repository, IEventStore eventStore)
    {
        _eventStore = eventStore;
        _repository = repository;
    }

    public async Task Handle(UpdateCustomerCommand command, CancellationToken cancellationToken = default)
    {
        if (await _repository.AnyAsync(e => e.Id != command.CustomerId.Value && e.Email == command.Email.Value, cancellationToken))
            throw new CustomerAlreadyExistsException(command.Email.Value);
        if (await _repository.AnyAsync(x => x.Id != command.CustomerId.Value && x.FirstName == command.FirstName.Value && x.LastName == command.LastName.Value && x.DateOfBirth == command.DateOfBirth.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc), cancellationToken))
            throw new CustomerAlreadyExistsException(command.FirstName.Value, command.LastName.Value, command.DateOfBirth);

        Customer? aggregate = await _repository.SingleOrDefaultAsync(e => e.Id == command.CustomerId.Value, cancellationToken);
        if (aggregate == null)
            throw new CustomerNotFoundException(command.CustomerId.Value);

        aggregate.AppendEvent(new CustomerUpdatedEvent(command.FirstName, command.LastName, command.DateOfBirth, command.Phone, command.Email, command.BankAccountNumber));
        _repository.Update(aggregate);

        await _repository.SaveChangesAsync(cancellationToken);
        _eventStore.Commit(aggregate.Id, aggregate.Events);
    }
}