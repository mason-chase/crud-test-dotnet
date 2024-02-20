using CrudTest.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Services.Features.Marketing.Customers.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerResponse>
    {
        private readonly MarketingDbContext _context;

        public UpdateCustomerCommandHandler(MarketingDbContext context)
        {
            _context = context;
        }
        public async Task<UpdateCustomerResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == request.CustomerId);

            if (customer == null)
            {
                return new UpdateCustomerResponse
                {
                    StatusCode = 404,
                    Success = false,

                };
            }


            customer.Update(request.FirstName, request.LastName,
                request.DateOfBirth,
                request.PhoneNumber,
                request.Email,
                request.BankAccountNumber);

            await _context.SaveChangesAsync();

            return new UpdateCustomerResponse
            {
                Success = true,
                StatusCode = 200,
            };

        }
    }
}
