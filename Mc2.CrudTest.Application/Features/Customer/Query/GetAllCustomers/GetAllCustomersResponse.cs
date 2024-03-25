using Mc2.CrudTest.Domain.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mc2.CrudTest.Application.Features.Customer.Query.GetAllCustomers;

public class GetAllCustomersResponse : BaseModel
{
    [BsonElement("id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string FirstName { get; set;}
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string BankAccountNumber { get; set; }
}