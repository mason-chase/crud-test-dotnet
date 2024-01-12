using Application.Behaviours;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging; 

namespace Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomerCommandHandler> _logger; 

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<CreateCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
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


                // if (!CustomerValidator.IsValidBankAccountNumber(request.BankAccountNumber))
                // {
                //     _logger.LogError("Invalid BankAccountNumber");
                //     throw new Exception("Invalid BankAccountNumber");
                // }

                var customer = _mapper.Map<Customer>(request);
                await _customerRepository.AddAsync(customer);

                _logger.LogInformation($"Customer created successfully. CustomerId: {customer.Id}");

                return customer.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating customer: {ex.Message}");
                throw;
            }
        }
    }
}