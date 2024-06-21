using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Mc2.CrudTest.Shared.BuildingBlocks.AggregateRoot;

namespace Mc2.CrudTest.Modules.Customers.Domain.Models;

public partial record Email : ValueObject
{
    private static readonly Regex Regex = EmailRegex();

    private Email(string value)
    {
        Value = value;
    }

    public string Value { get; }

    /// <exception cref="ValidationException">Thrown when the given value is not valid.</exception>
    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException("Email address is required", new ArgumentException(nameof(value)));

        if (value.Length > 255)
            throw new ValidationException("Email address must be between 5 and 255 characters", new ArgumentException(nameof(value)));

        Match match = Regex.Match(value);
        if (!match.Success || match.Index != 0 || match.Length != value.Length)
            throw new ValidationException("Invalid email address format.");

        try
        {
            MailAddress mailAddress = new(value);
            return new Email(mailAddress.Address);
        }
        catch (Exception e)
        {
            throw new ValidationException("Invalid email address format.", e);
        }
    }

    [GeneratedRegex("^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.Compiled)]
    private static partial Regex EmailRegex();
}