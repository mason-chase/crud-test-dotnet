namespace Mc2.Framework.Domain.Events;

public interface IEventHandler<in TEvent> where TEvent : IEvent
{
    void Handle(TEvent @event);
}