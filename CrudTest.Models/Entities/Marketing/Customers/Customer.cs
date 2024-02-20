using CrudTest.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Models.Entities.Marketing.Customers
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; private set; } = null!;

        public string LastName { get; private set; } = null!;

        public DateOnly DateOfBirth { get; private set; }

        public ulong PhoneNumber { get; private set; }

        public string Email { get; private set; } = null!;

        public ulong BankAccountNumber { get; private set; }

        private Customer()
        {

        }

        private Customer(Guid id)
        {
            Id = id;
        }


        public static Customer Create(string firstName, string lastName,
            DateOnly dateOfBirth, ulong phoneNumber,
            string email, ulong bankAccountNumber)
        {
            //Todo: Add domain level validation and throw exception in case bad data was entered

            return new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                BankAccountNumber = bankAccountNumber,
                Email = email,
                PhoneNumber = phoneNumber,
            };
        }

        public void Update(string firstName, string lastName,
            DateOnly dateOfBirth, ulong phoneNumber,
            string email, ulong bankAccountNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            BankAccountNumber = bankAccountNumber;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
