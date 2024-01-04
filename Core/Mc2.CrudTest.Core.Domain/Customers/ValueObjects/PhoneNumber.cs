using Mc2.CrudTest.Framework.Domain.ValueObjects;
using PhoneNumbers;

namespace Mc2.CrudTest.Core.Domain.Customers.ValueObjects
{
    public class PhoneNumber : BaseValueObject<PhoneNumber>
    {

        public string Value { get; private set; }
        public static PhoneNumber FromString(string value) => new PhoneNumber(value);

        private PhoneNumber()
        {

        }

        public PhoneNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Phone Number is required.", nameof(value));
            }
            try {
                var phoneUtil = PhoneNumberUtil.GetInstance();

                var numberProto = phoneUtil.Parse(value, "CA");
                if (!phoneUtil.IsValidNumber(numberProto))
                {
                    throw new ArgumentException("Invalid Phone Number.", nameof(value));
                }
                Value = value;
            }
            catch
            {
                throw new ArgumentException("Invalid Phone Number.", nameof(value));
            }
            
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(PhoneNumber otherObject) => Value == otherObject.Value;

        public static implicit operator string(PhoneNumber advertismentTitle) => advertismentTitle.Value;
    }
}
