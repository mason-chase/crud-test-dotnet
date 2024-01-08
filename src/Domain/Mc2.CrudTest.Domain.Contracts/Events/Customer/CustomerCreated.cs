using Mc2.Framework.Domain.Events;

namespace Mc2.CrudTest.Domain.Contracts.Events.Customer;

public class CustomerCreated(
    long id,
    string firstname,
    string lastname,
    DateTime dateOfBirth,
    string phoneNumber,
    string email,
    string bankAccountNumber) : DomainEvent
{
    public long Id { get; private set; } = id;
    public string Firstname { get; private set; } = firstname;
    public string Lastname { get; private set; } = lastname;
    public DateTime DateOfBirth { get; private set; } = dateOfBirth;
    public string PhoneNumber { get; private set; } = phoneNumber;
    public string Email { get; private set; } = email;
    public string BankAccountNumber { get; private set; } = bankAccountNumber;
}