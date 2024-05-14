using Mc2.CrudTest.Presentation.Shared.Entities;
using Mc2.CrudTest.Presentation.Shared.Events;

namespace MC2.CrudTest.UnitTests;

public class UnitTest1
{
    [Fact]
    public void Apply_CustomerDeletedEvent_SetsDeletedFlag()
    {
        // Arrange
        var customer = new Customer(Guid.NewGuid(), "Mohammad", "Dehghani", "1234567890", "a@gmail.com", "123456");
        var deletedEvent = new CustomerDeletedEvent(customer.Id);

        // Act
        customer.Apply(deletedEvent);

        // Assert
        Assert.True(customer.IsDeleted);
    }
    [Fact]
    public void Apply_CustomerCreatedEvent_AppliesCorrectly()
    {
        // Arrange
        var customerCreatedEvent = new CustomerCreatedEvent
        (
             Guid.NewGuid(),
             "Mohammad",
             "Dehghani",
             "00989010596159",
             "a@gmail.com",
             "1234564"
        );

        // Act
        var customer = new Customer();
        customer.Apply(customerCreatedEvent);

        // Assert
        Assert.Equal("Mohammad", customer.FirstName.ToString());
        Assert.Equal("Dehghani", customer.LastName.ToString());
        Assert.Equal("a@gmail.com", customer.Email.ToString()); 
    }
}