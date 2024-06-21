using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using FluentAssertions;
using Mc2.CrudTest.Modules.Customers.Domain.Models;

namespace Mc2.CrudTest.Modules.Customers.Tests.ModelsTests;

public class EmailTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Create_should_throw_ValidationException_when_value_IsNullOrWhiteSpace(string value)
    {
        // Act
        Action act = () => Email.Create(value);

        // Assert
        act.Should().Throw<ValidationException>().WithMessage("Email address is required*");
    }

    [Fact]
    public void Create_should_throw_ValidationException_when_value_Length_is_less_than_5()
    {
        // Arrange
        string value = "a@b.c";

        // Act
        Action act = () => Email.Create(value);

        // Assert
        act.Should().Throw<ValidationException>().WithMessage("Invalid email address format.");
    }

    [Fact]
    public void Create_should_throw_ValidationException_when_value_Length_is_greater_than_255()
    {
        // Arrange
        string value = new string('a', 256);

        // Act
        Action act = () => Email.Create(value);

        // Assert
        act.Should().Throw<ValidationException>().WithMessage("Email address must be between 5 and 255 characters*");
    }

    [Theory]
    [InlineData("abbbbb.c")]
    [InlineData("@ccccc.d")]
    [InlineData("aaaaa@d")]
    [InlineData("a d@e.f")]
    [InlineData("a@b.c")]
    [InlineData("a.b@c.d")]
    [InlineData("a.b.c@d.e")]
    public void Create_should_throw_ValidationException_when_value_is_not_valid(string value)
    {
        // Act
        Action act = () => Email.Create(value);

        // Assert
        act.Should().Throw<ValidationException>().WithMessage("Invalid email address format.");
    }

    [Theory]
    [InlineData("arash@shabbeh.com")]
    [InlineData("info@crud.ai")]
    [InlineData("arash.shabbeh@gmail.com")]
    [InlineData("arash_shabbeh@outlook.com")]
    public void Create_should_cause_Creating_MailAddress(string value)
    {
        // Act
        Email email = Email.Create(value);

        // Assert
        email.Value.Should().Be(value);
    }
}