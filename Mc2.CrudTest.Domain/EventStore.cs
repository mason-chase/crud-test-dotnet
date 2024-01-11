namespace Mc2.CrudTest.Domain;

public class EventStore : BaseEvent
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public string Data { get; private init; }

    public EventStore(Guid aggregateId, string messageType, string data)
    {
        AggregateId = aggregateId;
        MessageType = messageType;
        Data = data;
    }

    public EventStore() { }
}
