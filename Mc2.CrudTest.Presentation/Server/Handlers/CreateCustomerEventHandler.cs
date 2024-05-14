using Mc2.CrudTest.Presentation.Infrastructure;
using Mc2.CrudTest.Presentation.Shared.Commands;
using Mc2.CrudTest.Presentation.Shared.Events;
using MediatR;

namespace Mc2.CrudTest.Presentation.Handlers;

public class CreateCustomerEventHandler : INotification
{
private readonly IEventRepository _eventStore;

public CreateCustomerEventHandler(IEventRepository eventStore)
{
    _eventStore = eventStore;
}
public async Task Handle(CreateCustomerCommand command)
{
    var @event = new CustomerCreatedEvent(command.CustomerId, command.FirstName, command.LastName, command.PhoneNumber, command.Email, command.BankAccount);
    await _eventStore.SaveEventAsync(@event);
}
}