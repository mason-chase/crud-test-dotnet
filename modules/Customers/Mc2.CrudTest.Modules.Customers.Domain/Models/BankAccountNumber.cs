using System.ComponentModel.DataAnnotations;
using Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;

namespace Mc2.CrudTest.Modules.Customers.Domain.Models;

public record BankAccountNumber : ValueObject
{
    private BankAccountNumber(string value)
    {
        Value = value;
    }

    public string Value { get; }

    /// <exception cref="ValidationException">Thrown when the given value is not valid.</exception>
    public static BankAccountNumber Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException("Bank Account Number is required", new ArgumentException(nameof(value)));

        return new BankAccountNumber(value);
    }
}