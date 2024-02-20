using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Services.Features.Marketing.Customers.DeleteCustomer
{
    public class DeleteCustomerCommand: IRequest<DeleteCustomerResponse>
    {
        public Guid CustomerId { get; set; }

        public DeleteCustomerCommand(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
