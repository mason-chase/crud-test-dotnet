

using Mc2.CrudTest.Core.Domain.Customer.ValueObjects;
using Mc2.CrudTest.Framework.Domain.Entities;

namespace Mc2.CrudTest.Core.Domain.Customer.Entities
{
    public class Customer : BaseEntity<Guid>
    {
        #region Fields
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public DateTime DateOfBirth { get; protected set; }
        public Email Email { get; protected set; }
        public PhoneNumber PhoneNumber { get; protected set; }
        public BankAccountNumber BankAccountNumber { get; protected set; }
        #endregion

        public Customer(string firstName, string lastName, DateTime date)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = date;
        }

        public void SetEmail(Email email)
        {
            Email = email;
        }


        public void SetPhoneNumber(PhoneNumber phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }


        public void SetBankAccountNumber(BankAccountNumber accountNumber)
        {
            BankAccountNumber = accountNumber;
        }


    }
}
