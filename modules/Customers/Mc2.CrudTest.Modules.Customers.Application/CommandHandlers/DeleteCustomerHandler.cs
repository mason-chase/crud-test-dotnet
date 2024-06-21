using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.DeleteCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.Exceptions;
using Mc2.CrudTest.Modules.Customers.Domain.Models;
using Mc2.CrudTest.Shared.BuildingBlocks.CQRS;
using Mc2.CrudTest.Shared.BuildingBlocks.Stores;

namespace Mc2.CrudTest.Modules.Customers.Application.CommandHandlers;

public class DeleteCustomerHandler : ICommandHandler<DeleteCustomerCommand>
{
    private readonly IEventStore _eventStore;
    private readonly IRepository<Customer, CustomerId> _repository;

    public DeleteCustomerHandler(IRepository<Customer, CustomerId> repository, IEventStore eventStore)
    {
        _eventStore = eventStore;
        _repository = repository;
    }

    public async Task Handle(DeleteCustomerCommand command, CancellationToken cancellationToken = default)
    {
        Customer? aggregate = await _repository.SingleOrDefaultAsync(e => e.Id == command.CustomerId.Value, cancellationToken);
        if (aggregate == null)
            throw new CustomerNotFoundException(command.CustomerId.Value);

        aggregate.AppendEvent(new CustomerDeletedEvent());

        _repository.Remove(aggregate);

        await _repository.SaveChangesAsync(cancellationToken);
        _eventStore.Commit(aggregate.Id, aggregate.Events);
    }
}