using Mc2.CrudTest.Shared.BuildingBlocks.Exceptions;

namespace Mc2.CrudTest.Modules.Customers.Domain.Exceptions;

public class CustomerAlreadyExistsException : BadRequestException
{
    public CustomerAlreadyExistsException(string email) : base($"Customer with email {email} already exists.")
    {
        Email = email;
    }

    public CustomerAlreadyExistsException(string firstName, string lastName, DateOnly dateOfBirth) : base($"Customer with name {firstName} {lastName} and date of birth {dateOfBirth} already exists.")
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public DateOnly DateOfBirth { get; }
    public string Email { get; }
}