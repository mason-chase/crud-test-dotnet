using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using Mc2.CrudTest.Modules.Customers.Domain.Models;

namespace Mc2.CrudTest.Modules.Customers.Tests.ModelsTests;

public class NameTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Create_should_throw_ValidationException_when_value_IsNullOrWhiteSpace(string value)
    {
        // Act
        Action act = () => Name.Create(value);

        // Assert
        act.Should().Throw<ValidationException>().WithMessage("Name is required*");
    }

    [Fact]
    public void Create_should_throw_ValidationException_when_value_Length_is_less_than_2()
    {
        // Arrange
        string value = "a";

        // Act
        Action act = () => Name.Create(value);

        // Assert
        act.Should().Throw<ValidationException>().WithMessage("Name must be between 2 and 255 characters*");
    }

    [Fact]
    public void Create_should_throw_ValidationException_when_value_Length_is_greater_than_255()
    {
        // Arrange
        string value = new string('a', 256);

        // Act
        Action act = () => Name.Create(value);

        // Assert
        act.Should().Throw<ValidationException>().WithMessage("Name must be between 2 and 255 characters*");
    }

    [Fact]
    public void Create_should_cause_Creating_Name_instance()
    {
        // Arrange
        string value = "John Doe";

        // Act
        Name name = Name.Create(value);

        // Assert
        name.Value.Should().Be(value);
    }
}