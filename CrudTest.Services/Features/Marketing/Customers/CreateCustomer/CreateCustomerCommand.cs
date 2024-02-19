using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace CrudTest.Services.Features.Marketing.Customers.CreateCustomer
{
    public class CreateCustomerCommand: IRequest<int>
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public ulong PhoneNumber { get; set; }

        public string Email { get; set; } = null!;

        public ulong BankAccountNumber { get; set; }
    }
}
