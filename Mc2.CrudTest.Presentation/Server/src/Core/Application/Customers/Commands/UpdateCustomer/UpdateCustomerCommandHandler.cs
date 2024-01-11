using Application.Behaviours;
using Application.Customers.Commands.UpdateCustomer;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCustomerCommandHandler> _logger;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<UpdateCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!CustomerValidator.IsValidEmail(request.Email))
                {
                    _logger.LogError("Invalid email format");
                    throw new Exception("Invalid email format");
                }

                if (!CustomerValidator.IsValidPhoneNumber(request.PhoneNumber))
                {
                    _logger.LogError("Invalid phone number");
                    throw new Exception("Invalid phone number");
                }

                var customer = _mapper.Map<Customer>(request);
                bool result = await _customerRepository.UpdateAsync(customer);

                if (result)
                {
                    _logger.LogInformation($"Customer with ID {request.Id} updated successfully.");
                }
                else
                {
                    _logger.LogWarning($"Customer with ID {request.Id} not found for update.");
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating customer: {ex.Message}");
                throw;
            }
        }
    }
}
