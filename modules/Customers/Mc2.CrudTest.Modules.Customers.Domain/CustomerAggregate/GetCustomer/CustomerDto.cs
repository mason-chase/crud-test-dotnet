using System.Text.Json.Serialization;

namespace Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.GetCustomer;

public class CustomerDto
{
    [JsonPropertyName("customerId")] public int Id { get; init; }

    [JsonPropertyName("firstName")] public string FirstName { get; init; }

    [JsonPropertyName("lastName")] public string LastName { get; init; }

    [JsonPropertyName("dateOfBirth")] public DateTime DateOfBirth { get; init; }

    [JsonPropertyName("phoneNumber")] public string PhoneNumber { get; init; }

    [JsonPropertyName("email")] public string Email { get; init; }

    [JsonPropertyName("bankAccountNumber")]
    public string BankAccountNumber { get; init; }
}