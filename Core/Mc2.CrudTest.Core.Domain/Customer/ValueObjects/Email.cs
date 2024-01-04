

using Mc2.CrudTest.Framework.Domain.ValueObjects;

namespace Mc2.CrudTest.Core.Domain.Customer.ValueObjects
{
    public class Email : BaseValueObject<Email>
    {

        public string Value { get; private set; }

        private Email()
        {

        }

        public Email(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Email is required.", nameof(value));
            }
            Value = value;
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(Email otherObject) => Value == otherObject.Value;

        public static implicit operator string(Email advertismentTitle) => advertismentTitle.Value;
    }
}
