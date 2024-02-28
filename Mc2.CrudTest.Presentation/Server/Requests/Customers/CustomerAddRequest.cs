using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Mc2.CrudTest.Presentation.Server.Requests.Customers;

public class CustomerAddRequest
{
    [Required]
    [NotNull]
    public string FirstName { get; set; }

    [Required]
    [NotNull]
    public string LastName { get; set; }

    [Required]
    public DateOnly DateOfBirth { get; set; }

    [Required]
    [NotNull]
    public string PhoneNumber { get; set; }

    [Required]
    [NotNull]
    public string Email { get; set; }

    [Required]
    [NotNull]
    public string BankAccount { get; set; }
}
