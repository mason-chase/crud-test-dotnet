using Application.Customers.Commands;
using Core.Interfaces;
using Core.Models;
using MediatR;

namespace Application.Customers.Handlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, (bool, string)>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(bool, string)> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var existingCustomer = await _unitOfWork.CustomerRepository.FindById(request.Id);

            if (existingCustomer is null)
            {
                return (false, "Customer not found.");
            }

            if (existingCustomer.Email != request.Email)
            {
                var existingCustomerWithEmail = await _unitOfWork.CustomerRepository.FindByEmail(request.Email);
                if (existingCustomerWithEmail != null)
                {
                    return (false, "Email already exists.");
                }
            }

            if (existingCustomer.FirstName != request.FirstName ||
                existingCustomer.LastName != request.LastName ||
                existingCustomer.DateOfBirth != request.DateOfBirth)
            {
                var existingCustomerWithDetails = await _unitOfWork.CustomerRepository.FirstOrDefaultAsync(c => c.FirstName == request.FirstName &&
                                                                                                   c.LastName == request.LastName &&
                                                                                                   c.DateOfBirth == request.DateOfBirth);
                if (existingCustomerWithDetails != null)
                {
                    return (false, "Customer with the same details already exists.");
                }
            }

            var customer = new Customer
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                BankAccountNumber = request.BankAccountNumber
            };

            var result = _unitOfWork.CustomerRepository.Update(customer);

            return result ? (true, "Customer updated successfully.") : (false, "There was a problem in update operation!");
        }
    }
}
