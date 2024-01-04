using Mc2.CrudTest.Framework.Domain.ValueObjects;
using PhoneNumbers;

namespace Mc2.CrudTest.Core.Domain.Customer.ValueObjects
{
    public class BankAccountNumber : BaseValueObject<BankAccountNumber>
    {

        public string Value { get; private set; }

        private BankAccountNumber()
        {

        }

        public BankAccountNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("BankAccountNumber is required.", nameof(value));
            }

            Value = value;
        }
        public override int ObjectGetHashCode() => Value.GetHashCode();
        public override bool ObjectIsEqual(BankAccountNumber otherObject) => Value == otherObject.Value;

        public static implicit operator string(BankAccountNumber advertismentTitle) => advertismentTitle.Value;
    }
}
