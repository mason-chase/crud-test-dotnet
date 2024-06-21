namespace Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;

public interface IAggregateRoot
{
}

public interface IAggregateRoot<TId> : IAggregateRoot
{
    IReadOnlyCollection<IDomainEvent<TId>> Events { get; }
    void ClearEvents();
}