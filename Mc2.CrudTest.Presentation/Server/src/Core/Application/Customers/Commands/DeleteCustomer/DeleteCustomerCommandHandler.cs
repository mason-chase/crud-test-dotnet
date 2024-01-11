using Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<DeleteCustomerCommandHandler> _logger;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, ILogger<DeleteCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool result = await _customerRepository.DeleteAsync(request.Id);

                if (result)
                {
                    _logger.LogInformation($"Customer with ID {request.Id} deleted successfully.");
                }
                else
                {
                    _logger.LogWarning($"Customer with ID {request.Id} not found for delete.");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting customer: {ex.Message}");
                throw;
            }
        }
    }
}