

using Mc2.CrudTest.Core.Domain.Customers.Events;
using Mc2.CrudTest.Core.Domain.Customers.ValueObjects;
using Mc2.CrudTest.Framework.Domain.Entities;
using Mc2.CrudTest.Framework.Domain.Events;

namespace Mc2.CrudTest.Core.Domain.Customers.Entities
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


        #region Constructors
        public Customer()
        {
        }

        public Customer(Guid id,
                        string firstName,
                        string lastName,
                        Email email,
                        PhoneNumber phoneNumber,
                        BankAccountNumber bankAccountNumber,
                        DateTime date)
        {
            HandleEvent(new CustomerCreatedEvent
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = date,
                Email = Email.Value,
                PhoneNumber = phoneNumber.Value,
                BankAccountNumber = bankAccountNumber.Value,
            });
        }
        #endregion

        public void UpdateCustomer(string firstName,
                                   string lastName,
                                   Email email,
                                   PhoneNumber phoneNumber,
                                   BankAccountNumber bankAccountNumber,
                                   DateTime date)
        {
            HandleEvent(new CustomerUpdatedEvent
            {
                Id = Id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = date,
                Email = email.Value,
                PhoneNumber = phoneNumber.Value,
                BankAccountNumber = bankAccountNumber.Value,
            });
        }


        public void DeleteCustomer()
        {
            HandleEvent(new CustomerUpdatedEvent
            {
                Id = Id,
            });
        }

        protected override void ValidateInvariants()
        {

        }

        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
                case CustomerCreatedEvent e:
                    Id = e.Id;
                    FirstName = e.FirstName;
                    LastName = e.FirstName;
                    DateOfBirth = e.DateOfBirth;
                    PhoneNumber = new PhoneNumber(e.PhoneNumber);
                    Email = new Email(e.Email);
                    BankAccountNumber = new BankAccountNumber(e.BankAccountNumber);
                    break;
                case CustomerUpdatedEvent e:
                    FirstName = e.FirstName;
                    LastName = e.FirstName;
                    DateOfBirth = e.DateOfBirth;
                    PhoneNumber = new PhoneNumber(e.PhoneNumber);
                    Email = new Email(e.Email);
                    BankAccountNumber = new BankAccountNumber(e.BankAccountNumber);
                    break;
                case CustomerDeletedEvent e:
                    break;
                default:
                    throw new InvalidOperationException("The operation is not implemented.");
            }
        }
    }
}
