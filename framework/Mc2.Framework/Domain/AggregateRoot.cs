using Mc2.Framework.Domain.Events;
using Mc2.Framework.Domain.Utils;

namespace Mc2.Framework.Domain;

public class AggregateRoot<TKey>:Entity<TKey>,IAggregateRoot
{
    private IEventPublisher _publisher;
    private readonly List<DomainEvent> _publishedEvents = new();

    protected AggregateRoot()
    {
    }
    
    public DateTime CreateOn { get; private set; }

    public bool IsDeleted { get; private set; }

    public DateTime? ActionTime { get; private set; }

    public long ActionUserId { get; private set; }

    public bool IsActive { get; private set; }

    public int RowVersion { get; private set; }

    protected void SetUserActionLog(IClock clock, long userActionId)
    {
        ActionTime = new DateTime?(clock.Now());
        ActionUserId = userActionId;
    }

    protected void Delete() => IsDeleted = true;

    protected void DeActive() => IsActive = false;

    protected void Active() => IsActive = true;

    protected void Recover() => IsDeleted = false;

    protected AggregateRoot(
        TKey id,
        IClock clock,
        IEventPublisher publisher,
        long actionUserId)
        : base(id)
    {
        CreateOn = clock.Now();
        _publisher = publisher;
        ActionUserId = actionUserId;
        IsActive = true;
        IsDeleted = false;
    }

    public void SetPublisher(IEventPublisher publisher) => _publisher = publisher;

    public void Publish<TEvent>(TEvent @event) where TEvent : DomainEvent
    {
        _publishedEvents.Add(@event);
        _publisher.Publish(@event);
    }

    public IReadOnlyList<DomainEvent> GetChanges()
    {
        return _publishedEvents;
    }

    public void ClearChanges() => _publishedEvents.Clear();
    
}