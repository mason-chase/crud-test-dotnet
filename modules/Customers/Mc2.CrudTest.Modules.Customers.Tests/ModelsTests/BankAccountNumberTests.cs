using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using Mc2.CrudTest.Modules.Customers.Domain.Models;

namespace Mc2.CrudTest.Modules.Customers.Tests.ModelsTests;

public class BankAccountNumberTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Create_should_throw_ValidationException_when_value_IsNullOrWhiteSpace(string value)
    {
        // Act
        Action act = () => BankAccountNumber.Create(value);

        // Assert
        act.Should().Throw<ValidationException>().WithMessage("Bank Account Number is required*");
    }

    [Theory]
    [InlineData("NL91ABNA0417164300")]
    [InlineData("NL91ABNA0417164301")]
    [InlineData("NL91ABNA0417164302")]
    public void Create_should_cause_Creating_BankAccountNumber(string value)
    {
        // Act
        var bankAccountNumber = BankAccountNumber.Create(value);

        // Assert
        bankAccountNumber.Value.Should().Be(value);
    }
}