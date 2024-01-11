using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await _customerRepository.BeginTransactionAsync();

            try
            {
                var isDeleted = await _customerRepository.DeleteAsync(request.Id);

                if (isDeleted)
                {
                    await _customerRepository.CommitTransactionAsync();
                }
                else
                {
                    await _customerRepository.RollbackTransactionAsync();
                }

                return isDeleted;
            }
            catch (Exception)
            {
                await _customerRepository.RollbackTransactionAsync();
                throw; 
            }
        }
    }
}