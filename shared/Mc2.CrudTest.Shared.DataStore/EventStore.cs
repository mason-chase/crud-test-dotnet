using System.Collections.Concurrent;
using Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;
using Mc2.CrudTest.Shared.BuildingBlocks.Stores;

namespace Mc2.CrudTest.Shared.DataStore;

public class EventStore : IEventStore
{
    private readonly ConcurrentDictionary<int, List<IDomainEvent>> _store = new();

    public void Commit(int aggregateId, IEnumerable<IDomainEvent> events)
    {
        foreach (IDomainEvent @event in events)
        {
            if (!_store.ContainsKey(aggregateId))
                _store.TryAdd(aggregateId, new List<IDomainEvent>());

            _store[aggregateId].Add(@event);
        }
    }

    public IReadOnlyList<IDomainEvent> GetEvents(int aggregateId)
    {
        return _store.TryGetValue(aggregateId, out List<IDomainEvent> events)
            ? events
            : new List<IDomainEvent>();
    }
}