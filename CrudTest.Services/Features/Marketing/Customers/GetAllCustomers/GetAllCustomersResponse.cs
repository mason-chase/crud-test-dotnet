using CrudTest.Models.Entities.Marketing.Customers;
using CrudTest.Services.Common;
using CrudTest.Services.Features.Marketing.Customers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Services.Features.Marketing.Customers.GetAllCustomers
{
    public class GetAllCustomersResponse: Response<List<CustomerResponseDto>>
    {
    }
}
