using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Behaviours;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Customers.Commands.UpdateCustomer;

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await _customerRepository.BeginTransactionAsync();

            try
            {
                if (!CustomerValidator.IsValidEmail(request.Email))
                {
                    await _customerRepository.RollbackTransactionAsync();
                    throw new Exception("Invalid email format");
                }

                if (!CustomerValidator.IsValidPhoneNumber(request.PhoneNumber))
                {
                    await _customerRepository.RollbackTransactionAsync();
                    throw new Exception("Invalid phone number");
                }

                var customer = new Customer
                {
                    Id = request.Id,
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    DateOfBirth = request.DateOfBirth,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email,
                    BankAccountNumber = request.BankAccountNumber
                };

                var isUpdated = await _customerRepository.UpdateAsync(customer);

                if (isUpdated)
                {
                    await _customerRepository.CommitTransactionAsync();
                }
                else
                {
                    await _customerRepository.RollbackTransactionAsync();
                }

                return isUpdated;
            }
            catch (Exception)
            {
                await _customerRepository.RollbackTransactionAsync();
                throw; 
            }
        }
    }

