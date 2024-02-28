using AutoFixture;
using FluentAssertions;
using IbanNet;
using Mc2.CrudTest.Application.Validators.Customers;
using Mc2.CrudTest.Domain.Commands;
using Xunit;

namespace Mc2.CrudTest.Tests.Validators.Customers;

public class AddCustomerCommandValidatorTests
{
    private Fixture _fixture { get { return new Fixture(); } }
    public AddCustomerCommandValidatorTests()
    {
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Add_Command_Validator_Should_Return_Invalid_When_FirstName_Is_Null_Or_Empty(string firstName)
    {
        var ibanValidator = new IbanValidator();
        var validator = new CustomerAddCommandValidator(ibanValidator);

        var customerAddCommand = new CustomerAddCommand(firstName, _fixture.Create<string>(), ValidDataSamples.PhoneNumber, ValidDataSamples.Email,
            ValidDataSamples.DateOfBirth, ValidDataSamples.Iban);

        var validationResult = validator.Validate(customerAddCommand);

        validationResult.IsValid.Should().Be(false);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Add_Command_Validator_Should_Return_Invalid_When_LastName_Is_Null_Or_Empty(string lastName)
    {
        var ibanValidator = new IbanValidator();
        var validator = new CustomerAddCommandValidator(ibanValidator);

        var customerAddCommand = new CustomerAddCommand(_fixture.Create<string>(), lastName, ValidDataSamples.PhoneNumber, ValidDataSamples.Email,
            ValidDataSamples.DateOfBirth, ValidDataSamples.Iban);

        var validationResult = validator.Validate(customerAddCommand);

        validationResult.IsValid.Should().Be(false);
    }



    [Theory]
    [InlineData("915")]
    [InlineData("915dd")]
    [InlineData("915 110")]
    [InlineData("z915 110")]
    [InlineData(null)]
    public void Add_Command_Validator_Should_Return_Invalid_When_PhoneNumber_Is_Null_Or_Empty_Or_Invalid(string phoneNumber)
    {
        var ibanValidator = new IbanValidator();
        var validator = new CustomerAddCommandValidator(ibanValidator);

        var customerAddCommand = new CustomerAddCommand(_fixture.Create<string>(), _fixture.Create<string>(), phoneNumber, ValidDataSamples.Email,
            ValidDataSamples.DateOfBirth, ValidDataSamples.Iban);

        var validationResult = validator.Validate(customerAddCommand);

        validationResult.IsValid.Should().Be(false);
    }


    [Theory]
    [InlineData("ab915")]
    [InlineData("IR915dd")]
    [InlineData("915 110")]
    [InlineData("AZ915 1102 2121 2121 212")]
    [InlineData(null)]
    public void Add_Command_Validator_Should_Return_Invalid_When_Iban_Is_Null_Or_Empty_Or_Invalid(string iban)
    {
        var ibanValidator = new IbanValidator();
        var validator = new CustomerAddCommandValidator(ibanValidator);

        var customerAddCommand = new CustomerAddCommand(_fixture.Create<string>(), _fixture.Create<string>(), ValidDataSamples.PhoneNumber, ValidDataSamples.Email,
          ValidDataSamples.DateOfBirth, iban);

        var validationResult = validator.Validate(customerAddCommand);

        validationResult.IsValid.Should().Be(false);
    }


    [Theory]
    [InlineData("a#b")]
    [InlineData("")]
    [InlineData("dfjsdlkf.com")]
    [InlineData(null)]
    public void Add_Command_Validator_Should_Return_Invalid_When_Email_Is_Null_Or_Empty_Or_Invalid(string email)
    {
        var ibanValidator = new IbanValidator();
        var validator = new CustomerAddCommandValidator(ibanValidator);

        var customerAddCommand = new CustomerAddCommand(_fixture.Create<string>(), _fixture.Create<string>(), ValidDataSamples.PhoneNumber, email,
          ValidDataSamples.DateOfBirth, ValidDataSamples.Iban);

        var validationResult = validator.Validate(customerAddCommand);

        validationResult.IsValid.Should().Be(false);
    }
}
