using Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Customers
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ulong PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}