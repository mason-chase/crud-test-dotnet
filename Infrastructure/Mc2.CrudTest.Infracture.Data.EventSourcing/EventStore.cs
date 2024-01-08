using EventStore.ClientAPI;
using Mc2.CrudTest.Framework.Domain.Data;
using Mc2.CrudTest.Framework.Domain.Events;
using Newtonsoft.Json;
using System.Text;

namespace Mc2.CrudTest.Infracture.Data.EventSourcing
{
    public class EventStore : IEventSource
    {

        private readonly IEventStoreConnection _connection;
        public EventStore(IEventStoreConnection connection)
        {
            _connection = connection;
            connection.ConnectAsync().Wait();   
        }
        public void Save<TEvent>(string aggregateName, string streamId, IEnumerable<TEvent> events) where TEvent : IEvent
        {
                if (!events.Any()) return;

                var changes = events.Select(@event => new EventData(
                                                           eventId: Guid.NewGuid(),
                                                           type: @event.GetType().Name,
                                                           isJson: true,
                                                           data: Serialize(@event),
                                                           metadata: Serialize(new EventMetadata { ClrType = @event.GetType().AssemblyQualifiedName }
                                                           )))
                                                           .ToArray();
                var streamName = $"{aggregateName}-{streamId}";
                _connection.AppendToStreamAsync(streamName, ExpectedVersion.Any, changes).Wait();
        }

   

        private static byte[] Serialize(object data) => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));

       
    }

    internal class EventMetadata
    {
        public string ClrType { get; set; }
    }
}
