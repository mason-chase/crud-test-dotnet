using Mc2.CrudTest.Framework.Domain.Events;

namespace Mc2.CrudTest.Framework.Domain.Data
{
    public interface IEventSource
    {
        void Save<TEvent>(string aggregateName, string streamId, IEnumerable<TEvent> events) where TEvent : IEvent;
    }
}
