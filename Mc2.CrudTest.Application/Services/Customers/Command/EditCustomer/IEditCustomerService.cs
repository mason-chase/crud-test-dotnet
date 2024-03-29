using Mc2.CrudTest.Application.Interfaces.Context;
using Mc2.CrudTest.Application.Services.Customers.Command.RegisterCustomer;
using Mc2.CrudTest.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Services.Customers.Command.EditCustomer
{
    public interface IEditCustomerService
    {
        ResultDto Execute(long CustomerId, EditCustomerDto request);
    }
    public class EditCustomerService : IEditCustomerService
    {
        private readonly IDataBaseContext _context;
        public EditCustomerService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long CustomerId, EditCustomerDto request)
        {
            try
            {
                var customer = _context.Customers.Find(CustomerId);
                if (customer == null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "User not found"
                    };
                }
                customer.FirstName = request.FirstName;
                customer.LastName = request.LastName;
                customer.PhoneNumber = request.PhoneNumber;
                customer.Email = request.Email;
                customer.DateOfBirth = request.DateOfBirth;
                customer.BankAccountNumber = request.BankAccountNumber;
                _context.SaveChanges();
                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "Succesful"
                };
            }
            catch (Exception ex)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "Faild"
                };
            }
        }
    }
    public class EditCustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ulong PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
