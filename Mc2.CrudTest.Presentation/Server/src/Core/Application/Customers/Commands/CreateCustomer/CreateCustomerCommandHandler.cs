using Application.Behaviours;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
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
        await _customerRepository.AddAsync(customer);
        return customer.Id;
    }
}