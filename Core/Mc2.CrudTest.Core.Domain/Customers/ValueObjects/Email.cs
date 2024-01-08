
using Mc2.CrudTest.Framework.Domain.ValueObjects;
using Mc2.CrudTest.Framework.Tool.Helper;

namespace Mc2.CrudTest.Core.Domain.Customers.ValueObjects
{
    public class Email : BaseValueObject<Email>
    {
        public string Value { get; private set; }
        public static Email FromString(string value) => new Email(value);

        private Email() { }

        public Email(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Email is required.", nameof(value));
            }
            if (!ValidationHelper.IsValidEmail(value))
            {
                throw new ArgumentException("Email is not valid.", nameof(value));
            }
            Value = value;
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(Email otherObject) => Value == otherObject.Value;
        public static implicit operator string(Email email) => email.Value;
    }
}
