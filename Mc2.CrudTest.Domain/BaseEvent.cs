using MediatR;

namespace Mc2.CrudTest.Domain;

public abstract class BaseEvent : INotification
{
    public string MessageType { get; protected init; }
    public Guid AggregateId { get; protected init; }
    public DateTime OccurredOn { get; private init; } = DateTime.Now;
}
