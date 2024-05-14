using Mc2.CrudTest.Presentation.Shared.Events;

namespace Mc2.CrudTest.Presentation.Shared.ReadModels;

public class CustomerReadModel:EventBase
{
   
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string BankAccount { get; set; }
    public Guid AggregateId { get; set; }
    public DateTimeOffset OccurredOn { get; set; }
}