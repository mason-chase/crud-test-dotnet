using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mc2.CrudTest.Domain.Models;

public class CustomerModel : BaseModel
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