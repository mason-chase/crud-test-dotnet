using System.ComponentModel.DataAnnotations;
using Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;
using PhoneNumbers;

namespace Mc2.CrudTest.Modules.Customers.Domain.Models;

public record Phone : ValueObject
{
    private static readonly PhoneNumberUtil PhoneNumberUtil = PhoneNumberUtil.GetInstance();

    private Phone(ulong value)
    {
        Value = value;
    }

    public ulong Value { get; }

    /// <exception cref="ValidationException">Thrown when the given value is not valid.</exception>
    public static Phone Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException("Phone number is required", new ArgumentException(nameof(value)));

        if (!value.StartsWith("+", StringComparison.OrdinalIgnoreCase) && !value.StartsWith("00", StringComparison.OrdinalIgnoreCase))
            throw new ValidationException("Phone number should start with region code");

        if (!value.StartsWith("+", StringComparison.OrdinalIgnoreCase) && value.StartsWith("00", StringComparison.OrdinalIgnoreCase))
            value = $"+{value[2..]}";

        PhoneNumber.Builder builder = new()
        {
            CountryCodeSource = PhoneNumber.Types.CountryCodeSource.FROM_NUMBER_WITH_PLUS_SIGN,
            RawInput = value,
            NumberOfLeadingZeros = 0
        };

        try
        {
            PhoneNumberUtil.ParseAndKeepRawInput(value, null, builder);
            PhoneNumber? pn = builder.Build();
            PhoneNumberType numberType = PhoneNumberUtil.GetNumberType(pn);
            if (numberType != PhoneNumberType.MOBILE && numberType != PhoneNumberType.FIXED_LINE_OR_MOBILE)
                throw new ValidationException("Phone number should be a Valid Mobile Number");

            return new Phone(ulong.Parse(value));
        }
        catch (NumberParseException e)
        {
            throw new ValidationException("Phone Number not recognized", e);
        }
    }
}