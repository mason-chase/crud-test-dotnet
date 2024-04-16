using Mc2.CrudTest.Application.Interfaces.Context;
using Mc2.CrudTest.Domain.Dto;
using Mc2.CrudTest.Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Services.Customers.Command.RegisterCustomer
{
    public interface IRegisterCustomerService
    {
        ResultDto<ResultRegisterCustomerDto> Execute(CustomerDto request);
    }
    public class RegisterCustomerService : IRegisterCustomerService
    {
        private readonly IDataBaseContext _context;
        public RegisterCustomerService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRegisterCustomerDto> Execute(CustomerDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDto<ResultRegisterCustomerDto>()
                    {
                        Data = new ResultRegisterCustomerDto()
                        {
                            CustomerId = 0,
                        },
                        IsSuccess = false,
                        Message = "Email is require"
                    };
                }
                string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";
                var match = Regex.Match(request.Email, emailRegex, RegexOptions.IgnoreCase);
                if (!match.Success)
                {
                    return new ResultDto<ResultRegisterCustomerDto>()
                    {
                        Data = new ResultRegisterCustomerDto()
                        {
                            CustomerId = 0,
                        },
                        IsSuccess = false,
                        Message = "wrong email address"
                    };
                }



                Customer customer = new Customer()
                {
                   FirstName=request.FirstName,
                   LastName=request.LastName,
                   DateOfBirth=request.DateOfBirth,
                   PhoneNumber=request.PhoneNumber,
                   Email=request.Email,
                   BankAccountNumber=request.BankAccountNumber
                };

              

              

                _context.Customers.Add(customer);

                _context.SaveChanges();

                return new ResultDto<ResultRegisterCustomerDto>()
                {
                    Data = new ResultRegisterCustomerDto()
                    {
                        CustomerId = customer.Id,
                    },
                    IsSuccess = true,
                    Message = "Successful",
                };
            }
            catch (Exception)
            {
                return new ResultDto<ResultRegisterCustomerDto>()
                {
                    Data = new ResultRegisterCustomerDto()
                    {
                        CustomerId = 0,
                    },
                    IsSuccess = false,
                    Message = "Failed!"
                };
            }
        }
    }
    public class ResultRegisterCustomerDto
    {
        public long CustomerId { get; set; }
    }
}
