using CrudTest.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Services.Features.Marketing.Customers.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerResponse>
    {
        private readonly MarketingDbContext _context;

        public DeleteCustomerCommandHandler(MarketingDbContext context)
        {
            _context = context;
        }
        public async Task<DeleteCustomerResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == request.CustomerId);

            if (customer == null)
            {
                return new DeleteCustomerResponse
                {
                    Success = false,
                    StatusCode = 404
                };
            }

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();

            return new DeleteCustomerResponse
            {
                Success = true,
                StatusCode = 200
            };
        }
    }
}
