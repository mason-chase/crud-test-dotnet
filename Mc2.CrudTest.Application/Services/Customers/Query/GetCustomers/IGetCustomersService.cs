using Mc2.CrudTest.Application.Interfaces.Context;
using Mc2.CrudTest.Domain.Dto;
using Mc2.CrudTest.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Services.Customers.Query.GetCustomers
{
    public interface IGetCustomersService
    {
        List<CustomerDto> Execute();
    }
   
    public class GetCustomersService : IGetCustomersService
    {
        private readonly IDataBaseContext _context;
        public GetCustomersService(IDataBaseContext context)
        {
            _context= context;
        }

        public List<CustomerDto> Execute()
        {
            var Customers = _context.Customers.Select(p => new CustomerDto
            {
                Id= p.Id,
                FirstName=p.FirstName,
                LastName=p.LastName,
                DateOfBirth=p.DateOfBirth,
                PhoneNumber= (ulong)p.PhoneNumber,
                Email=p.Email,
                BankAccountNumber=p.BankAccountNumber,
            }).ToList();
            return Customers;
          
        }
    }

}
