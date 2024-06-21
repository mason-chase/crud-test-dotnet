using System.Collections.Immutable;

namespace Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;

public abstract record AggregateRoot<TId> : IAggregateRoot<TId>
{
    private readonly List<IDomainEvent<TId>> _events = new();
    public IReadOnlyCollection<IDomainEvent<TId>> Events => _events.ToImmutableList();

    public void ClearEvents()
    {
        _events.Clear();
    }

    public void AppendEvent(IDomainEvent<TId> @event)
    {
        _events.Add(@event);
        OnAppend(@event);
    }

    protected abstract void OnAppend(IDomainEvent<TId> @event);
}