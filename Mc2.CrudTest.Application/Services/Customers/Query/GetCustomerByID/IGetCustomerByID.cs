using Mc2.CrudTest.Application.Interfaces.Context;
using Mc2.CrudTest.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Services.Customers.Query.GetCustomerByID
{
    public interface IGetCustomerByID
    {
        CustomerDto Execute(long id);
    }
    public class GetCustomerByID : IGetCustomerByID
    {
        private readonly IDataBaseContext _context;
        public GetCustomerByID(IDataBaseContext context)
        {
            _context = context;
        }
        public CustomerDto Execute(long Id)
        {
            var Customer = _context.Customers.FirstOrDefault(p => p.Id == Id);
            CustomerDto customerDto = new CustomerDto()
            {
                Id = Id,
                FirstName = Customer.FirstName,
                LastName = Customer.LastName,
                Email = Customer.Email,
                PhoneNumber = (ulong)Customer.PhoneNumber,
                DateOfBirth= Customer.DateOfBirth,
                BankAccountNumber= Customer.BankAccountNumber,
            };
            return customerDto;

        }
    }
}
