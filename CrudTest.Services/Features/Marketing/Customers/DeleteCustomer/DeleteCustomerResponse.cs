﻿using CrudTest.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Services.Features.Marketing.Customers.DeleteCustomer
{
    public class DeleteCustomerResponse: Response<object>
    {
        public int StatusCode { get; set; }
    }
}