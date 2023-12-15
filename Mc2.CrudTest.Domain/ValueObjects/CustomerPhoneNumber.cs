using Mc2.CrudTest.Domain.Exceptions;
using PhoneNumbers;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public class CustomerPhoneNumber
    {
        public long Value { get; }
        public CustomerPhoneNumber(long value)
        {
            if (value <= 0)
            {
                throw new InvalidPhoneNumberException(value.ToString());
            }
            Value = value;
        }
        public CustomerPhoneNumber(string value)
        {
            bool isValid = PhoneNumberUtil.IsViablePhoneNumber(value);
            if(!isValid)
            {
                throw new InvalidPhoneNumberException(value);
            }
            var numericString = new string(value.Where(c => char.IsDigit(c)).ToArray());
            Value=long.Parse(numericString);
        }
        public static implicit operator CustomerPhoneNumber(long value) => new CustomerPhoneNumber(value);
        public static implicit operator long(CustomerPhoneNumber value) => value.Value;

        public static implicit operator CustomerPhoneNumber(string value) => new CustomerPhoneNumber(value);
    }
}
