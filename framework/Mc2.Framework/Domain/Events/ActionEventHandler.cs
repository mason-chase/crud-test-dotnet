namespace Mc2.Framework.Domain.Events;

public class ActionEventHandler<TEvent>(Action<TEvent> action) : IEventHandler<TEvent>
    where TEvent : IEvent
{
    public void Handle(TEvent @event)
    {
        action(@event);
    }
}