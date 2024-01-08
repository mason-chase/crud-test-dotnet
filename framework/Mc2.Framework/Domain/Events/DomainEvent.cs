namespace Mc2.Framework.Domain.Events;

public class DomainEvent:IEvent
{
    public Guid EventId { get; set; } = Guid.NewGuid();
    public DateTime PublishDateTime { set; get; } = DateTime.Now;
}