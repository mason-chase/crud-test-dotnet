using Application.Customers.Commands;
using Core.Interfaces;
using Core.Models;
using MediatR;

namespace Application.Customers.Handlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, (int, string)>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(int, string)> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var existingCustomerWithEmail = await _unitOfWork.CustomerRepository.FindByEmail(request.Email);
            if (existingCustomerWithEmail != null)
            {
                return (0, "Email already exists.");
            }

            var existingCustomerWithDetails = await _unitOfWork.CustomerRepository.FirstOrDefaultAsync(c => c.FirstName == request.FirstName &&
                                                                                               c.LastName == request.LastName &&
                                                                                               c.DateOfBirth == request.DateOfBirth);
            if (existingCustomerWithDetails != null)
            {
                return (0, "Customer with the same details already exists.");
            }

            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                BankAccountNumber = request.BankAccountNumber
            };

            _ = _unitOfWork.CustomerRepository.Add(customer);

            return (customer.Id, "");
        }
    }
}
