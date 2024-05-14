namespace Mc2.CrudTest.Presentation.Shared.Events;

public class EventBase
{
   public Guid AggregateId { get; set; }
   public DateTimeOffset OccurredOn { get; protected set; }
  
   public Guid EventId { get; set; }
   
   public string AggregateType { get; set; }
   
   public string EventType { get; set; }
   
   public object Data { get; set; }
   
   public DateTime CreatedAt { get; set; }
   public EventBase()
   {
      AggregateId = Guid.NewGuid();
      OccurredOn = DateTimeOffset.UtcNow;
   }
}