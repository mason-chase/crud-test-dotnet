using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Shared.Abstraction.Domain;

namespace Mc2.CrudTest.Domain.Entities
{
    public class Customer: AggregateRoot<CustomerId>
    {
        public CustomerId Id { get; private set; }
        private CustomerFullName _fullName;
        private CustomerBirthday _birthday;
        private CustomerEmail _email;
        private CustomerBankAccountNumber _bankAccountNumber;
        private CustomerPhoneNumber _phoneNumber;
        public Customer()
        {
            
        }
        public Customer(
            CustomerId id,
            CustomerFullName fullName,
            CustomerBirthday birthday,
            CustomerEmail email,
            CustomerBankAccountNumber bankAccountNumber,
            CustomerPhoneNumber phoneNumber)
        {
            Id = id;
            _fullName = fullName;
            _birthday = birthday;
            _email = email;
            _bankAccountNumber = bankAccountNumber;
            _phoneNumber = phoneNumber;
        }
    }
}
