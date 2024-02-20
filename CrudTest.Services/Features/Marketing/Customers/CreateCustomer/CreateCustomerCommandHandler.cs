using CrudTest.Data.Context;
using CrudTest.Models.Entities.Marketing.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Services.Features.Marketing.Customers.CreateCustomer
{
    public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand,int>
    {
        private readonly MarketingDbContext _context;

        public CreateCustomerCommandHandler(MarketingDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var newCustomer = Customer.Create(request.FirstName,
                request.LastName,
                request.DateOfBirth,
                request.PhoneNumber,
                request.Email,
                request.BankAccountNumber
                );

            _context.Add( newCustomer );
            await _context.SaveChangesAsync();

            return 1;
        }
    }
}
