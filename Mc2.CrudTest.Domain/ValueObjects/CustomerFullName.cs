using Mc2.CrudTest.Domain.Exceptions;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public record CustomerFullName(string FirstName, string LastName)
    {
        public static CustomerFullName Create(string value)
        {
            var splitted=value.Split(',');
            var first = splitted.First();
            var last=splitted.Last();

            if (string.IsNullOrEmpty(first))
            {
                throw new InvalidFirstNameException(first);
            }
            if (string.IsNullOrEmpty(last))
            {
                throw new InvalidLastNameException(last);
            }
            return new CustomerFullName(splitted.First(), splitted.Last());
        }
        public override string ToString() => $"{FirstName},{LastName}";
    }
}
