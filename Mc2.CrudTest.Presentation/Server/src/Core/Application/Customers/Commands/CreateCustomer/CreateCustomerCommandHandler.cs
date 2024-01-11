using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
using MediatR;

namespace Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(request);
        await _customerRepository.AddAsync(customer);
        await _unitOfWork.SaveChangeAsync(cancellationToken);
        return customer.Id;
    }
}