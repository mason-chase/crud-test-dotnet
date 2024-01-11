using Mc2.CrudTest.Core;

namespace Mc2.CrudTest.Domain;

public class BaseEntity : IEntity<Guid>
{
    private readonly List<BaseEvent> _domainEvents = [];

    public Guid Id { get; private init; }
    public IEnumerable<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected BaseEntity() => Id = Guid.NewGuid();
    protected BaseEntity(Guid id) => Id = id;

    protected void AddDomainEvent(BaseEvent @event) => _domainEvents.Add(@event);
    public void ClearDomainEvents() => _domainEvents.Clear();
}
