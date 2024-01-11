using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Behaviours;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator; // Inject Mediator

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, IMediator mediator)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!CustomerValidator.IsValidEmail(request.Email))
            {
                throw new Exception("Invalid email format");
            }

            if (!CustomerValidator.IsValidPhoneNumber(request.PhoneNumber))
            {
                throw new Exception("Invalid phone number");
            }

            var customer = _mapper.Map<Customer>(request);

            using var transaction = await _customerRepository.BeginTransactionAsync();

            try
            {
                await _customerRepository.AddAsync(customer);
                await transaction.CommitAsync(cancellationToken);

                // Publish CustomerCreated event
                await _mediator.Publish(new CustomerCreatedEvent(customer.Id), cancellationToken);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }

            return customer.Id;
        }
    }
}