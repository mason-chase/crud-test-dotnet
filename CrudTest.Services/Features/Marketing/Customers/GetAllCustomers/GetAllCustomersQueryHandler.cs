using CrudTest.Data.Context;
using CrudTest.Models.Entities.Marketing.Customers;
using CrudTest.Services.Features.Marketing.Customers.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Services.Features.Marketing.Customers.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, GetAllCustomersResponse>
    {
        private readonly MarketingDbContext _context;

        public GetAllCustomersQueryHandler(MarketingDbContext context)
        {
            _context = context;
        }
        public async Task<GetAllCustomersResponse> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _context.Customers
                .Select(x=>new CustomerResponseDto
                {
                    BankAccountNumber = x.BankAccountNumber,
                    DateOfBirth = x.DateOfBirth,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber
                }).ToListAsync();

            return new GetAllCustomersResponse
            {
                Data = customers,
                Success = true
            };
        }
    }
}
