namespace Mc2.CrudTest.Presentation.Server.DataAccess.Enum
{
    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, IEnumerable<Event> events, int expectedVersion);
        List<Event> GetEventsForAggregate(Guid aggregateId);
    }

    // Events/Event.cs
    public abstract class Event
    {
        public Guid Id { get; protected set; }
        public int Version { get; set; }
    }


}
