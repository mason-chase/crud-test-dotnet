using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CrudTest.Services.Features.Marketing.Customers.UpdateCustomer
{
    public class UpdateCustomerCommand: IRequest<UpdateCustomerResponse>
    {
        [JsonIgnore]
        public Guid CustomerId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public ulong PhoneNumber { get; set; }

        public string Email { get; set; } = null!;

        public ulong BankAccountNumber { get; set; }
    }
}
