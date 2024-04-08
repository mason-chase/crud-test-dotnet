using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Customer
{
    public class CustomerListDto
    {
        public Guid Id { get; set; }
        public string InsertTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}