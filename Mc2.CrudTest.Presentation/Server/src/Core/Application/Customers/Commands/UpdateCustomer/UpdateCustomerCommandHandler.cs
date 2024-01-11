using Application.Behaviours;
using Application.Customers.Commands.UpdateCustomer;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
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
        return await _customerRepository.UpdateAsync(customer);
    }
}