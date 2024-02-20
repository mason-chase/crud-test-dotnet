using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Services.Features.Marketing.Customers.DTOs
{
    public class CustomerResponseDto
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public ulong PhoneNumber { get;  set; }

        public string Email { get; set; } = null!;

        public ulong BankAccountNumber { get; set; }
    }
}
