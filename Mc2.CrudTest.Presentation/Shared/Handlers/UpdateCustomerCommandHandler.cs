using Mc2.CrudTest.Presentation.Shared.Commands;
using MediatR;

namespace Mc2.CrudTest.Presentation.Shared.Handlers;

public class UpdateCustomerCommandHandler : INotification
{
    // Inject dependencies such as event store repository

    public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        // Load aggregate root from event store using PersonId
        // Apply update logic
        // Store the PersonUpdatedEvent in the event store
        // Publish the event to any subscribed event handle
        return Unit.Value;
    }
}