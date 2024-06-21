using System.Text.Json.Serialization;

namespace Mc2.CrudTest.Presentation.Server.Models.Requests;

public class UpdateCustomerRequested
{
    [JsonPropertyName("customerId")]
    public int CustomerId { get; init; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; init; }
    
    [JsonPropertyName("lastName")]
    public string LastName { get; init; }
    
    [JsonPropertyName("dateOfBirth")]
    public DateOnly DateOfBirth { get; init; }
    
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; init; }
    
    [JsonPropertyName("email")]
    public string Email { get; init; }
    
    [JsonPropertyName("bankAccountNumber")]
    public string BankAccountNumber { get; init; }
}