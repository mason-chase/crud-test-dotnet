using Mc2.CrudTest.Domain.Exceptions;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public record CustomerBirthday
    {
        public DateOnly Value { get;}
        public CustomerBirthday(DateOnly value)
        {
            if (value >= DateOnly.FromDateTime(DateTime.Now))
            {
                throw new InvalidBirthDayOnlyException(value);
            }
            Value = value;
        }
        public CustomerBirthday(string value)
        {
            var isValid= DateOnly.TryParse(value, out DateOnly date);
            if (!isValid || date >= DateOnly.FromDateTime(DateTime.Now))
            {
                throw new InvalidBirthDayOnlyException(value);
            }
            Value = date;
        }
        public static implicit operator CustomerBirthday(DateOnly value) => new CustomerBirthday(value);
        public static implicit operator DateOnly(CustomerBirthday value) => value.Value;
    }
}
