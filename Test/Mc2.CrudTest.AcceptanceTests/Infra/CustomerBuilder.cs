using Azure;
using Mc2.CrudTest.Core.Domain.Customers.Commands;
using Mc2.CrudTest.Core.Domain.Customers.Entities;
using Mc2.CrudTest.Core.Domain.Customers.ValueObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.Infra
{
    internal static class CustomerBuilder
    {
        public static Customer CreateCustomer()
        {
            var customer = new Customer("Sahar",
                "Amoorezaei",
                Email.FromString("saharamoorezaie@gmail.com"),
                PhoneNumber.FromString("+15879742883"),
                BankAccountNumber.FromString("123456789"),
                DateTime.Now
                );
            

            return customer;
        }

           
        public static Customer WithPhoneNumber(string phoneNumber)
        {
            return new Customer("Sahar",
     "Amoorezaei",
     Email.FromString("saharamoorezaie@gmail.com"),
     PhoneNumber.FromString(phoneNumber),
     BankAccountNumber.FromString("123456789"),
     DateTime.Now
     );
        }

        public static Customer WithEmail (string email)
        {
            return new Customer("Sahar",
            "Amoorezaei",
            Email.FromString(email),
            PhoneNumber.FromString("+15879742883"),
            BankAccountNumber.FromString("123456789"),
            DateTime.Now
            );
        }

    }
}
