using Mc2.CrudTest.Domain.Exceptions;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    //TODO if i had more time, policy
    public record Continent
    {
        public string Value { get; }
        public Continent(string value)
        {
            if (value == "Africa")
            {
                throw new NotSupportedRegion(value);
            }
            Value = value;
        }
        public static implicit operator Continent(string value) => new Continent(value);
        public static implicit operator string(Continent value) => value.Value;
    }
}
