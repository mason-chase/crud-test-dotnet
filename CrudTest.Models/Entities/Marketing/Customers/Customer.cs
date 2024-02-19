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
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public ulong PhoneNumber { get; set; }

        public string Email { get; set; } = null!;

        public string BankAccountNumber { get; set; } = null!;

        private Customer()
        {

        }

        public static Customer Create(string firstName, string lastName,
            DateOnly dateOfBirth, ulong phoneNumber,
            string email,string bankAccountNumber)
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
    }
}
