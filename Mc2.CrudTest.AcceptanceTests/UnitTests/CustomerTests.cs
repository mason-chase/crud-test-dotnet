using NUnit.Framework;

namespace Mc2.CrudTest.AcceptanceTests.UnitTests;

public class CustomerTests
{
    [Fact]
    public void Apply_CustomerDeletedEvent_SetsDeletedFlag()
    {
        // Arrange
        var person = new Customer(Guid.NewGuid(), "Mohamad", "Dehghani", "1234567890", "dehgh@gmail.com");
        var deletedEvent = new CustomerDeletedEvent(person.Id);

        // Act
        person.ApplyEvent(deletedEvent);

        // Assert
        Assert.True(person.IsDeleted);
    }
}