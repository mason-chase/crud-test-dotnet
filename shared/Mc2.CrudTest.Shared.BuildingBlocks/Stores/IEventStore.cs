using Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;

namespace Mc2.CrudTest.Shared.BuildingBlocks.Stores;

public interface IEventStore
{
    void Commit(int aggregateId, IEnumerable<IDomainEvent> events);
    IReadOnlyList<IDomainEvent> GetEvents(int aggregateId);
}