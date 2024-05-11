using Mc2.CrudTest.Presentation.Shared.Commands;
using MediatR;
namespace Mc2.CrudTest.Presentation.Shared.Handlers;

public class DeleteCustomerCommandHandler: INotification
{
    public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        // Load aggregate root from event store using CustomerId
        // Apply deletion logic
        // Store the CustomerDeletedEvent in the event store
        // Publish the event to queue
        return Unit.Value;
    }
    
}