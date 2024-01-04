using Mc2.CrudTest.Framework.Domain.ValueObjects;
using PhoneNumbers;

namespace Mc2.CrudTest.Core.Domain.Customer.ValueObjects
{
    public class PhoneNumber : BaseValueObject<PhoneNumber>
    {

        public string Value { get; private set; }

        private PhoneNumber()
        {

        }

        public PhoneNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Phone Number is required.", nameof(value));
            }
            var phoneUtil = PhoneNumberUtil.GetInstance();
            var numberProto = phoneUtil.Parse(value, "ZZ");
            if (phoneUtil.IsValidNumber(numberProto))
            {
                throw new ArgumentException("Invalid Phone Number.", nameof(value));
            }
            Value = value;
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(PhoneNumber otherObject) => Value == otherObject.Value;

        public static implicit operator string(PhoneNumber advertismentTitle) => advertismentTitle.Value;
    }
}
