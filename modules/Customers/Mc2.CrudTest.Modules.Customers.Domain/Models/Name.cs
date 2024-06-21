using System.ComponentModel.DataAnnotations;
using Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;

namespace Mc2.CrudTest.Modules.Customers.Domain.Models;

public record Name : ValueObject
{
    private Name(string value)
    {
        Value = value;
    }

    public string Value { get; }

    /// <exception cref="ValidationException">Thrown when the given value is not valid.</exception>
    public static Name Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException("Name is required", new ArgumentException(nameof(value)));

        if (value.Length is < 2 or > 255)
            throw new ValidationException("Name must be between 2 and 255 characters", new ArgumentException(nameof(value)));

        return new Name(value);
    }
}