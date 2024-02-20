using CrudTest.Models.Entities.Marketing.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Services.Features.Marketing.Customers.GetAllCustomers
{
    public class GetAllCustomersQuery: IRequest<GetAllCustomersResponse>
    {
    }
}
