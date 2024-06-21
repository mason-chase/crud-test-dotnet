using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using Mc2.CrudTest.Modules.Customers.Domain.Models;

namespace Mc2.CrudTest.Modules.Customers.Tests.ModelsTests;

public class PhoneTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Create_should_throw_ValidationException_when_value_IsNullOrWhiteSpace(string value)
    {
        // Act
        Action act = () => Phone.Create(value);

        // Assert
        act.Should().Throw<ValidationException>().WithMessage("Phone number is required*");
    }

    [Theory]
    [InlineData("1234567890")]
    [InlineData("09364091209")]
    public void Create_should_throw_ValidationException_when_value_is_not_started_with_plus_or_double_zero(string value)
    {
        // Act
        Action act = () => Phone.Create(value);

        // Assert
        act.Should().Throw<ValidationException>().WithMessage("Phone number should start with region code*");
    }

    [Theory]
    [InlineData("+123456789")]
    [InlineData("00123456789")]
    public void Create_should_throw_ValidationException_when_value_is_not_mobile(string value)
    {
        // Act
        Action act = () => Phone.Create(value);

        // Assert
        act.Should().Throw<ValidationException>().WithMessage("Phone number should be a Valid Mobile Number*");
    }

    [Theory]
    [InlineData("+989364091209")]
    [InlineData("00989364091209")]
    [InlineData("00905317251106")]
    [InlineData("+905317251106")]
    public void Create_should_cause_Creating_Phone_instance(string value)
    {
        // Act
        Phone phone = Phone.Create(value);

        // Assert
        phone.Value.Should().Be(ulong.Parse(value));
    }
}