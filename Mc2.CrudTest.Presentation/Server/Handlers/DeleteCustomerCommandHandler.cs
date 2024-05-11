using Mc2.CrudTest.Presentation.Infrastructure;
using Mc2.CrudTest.Presentation.Shared.Commands;
using Mc2.CrudTest.Presentation.Shared.Events;
using MediatR;
namespace Mc2.CrudTest.Presentation.Handlers;

public class DeleteCustomerCommandHandler: INotification
{
    private readonly IEventRepository _eventStore;

    public DeleteCustomerCommandHandler(IEventRepository eventStore)
    {
        _eventStore = eventStore;
    }
    
    public async Task<Unit> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
    {
        var @event = new CustomerDeletedEvent(command.CustomerId);
        await _eventStore.SaveEventAsync(@event);
        return Unit.Value;
    }
    
}