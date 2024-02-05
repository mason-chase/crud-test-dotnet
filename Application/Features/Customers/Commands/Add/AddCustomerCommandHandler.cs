using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Mc2.CrudTest.Presentation.Shared;
using MediatR;

namespace Application.Features.Customers.Commands.Add
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Result<int>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public AddCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }

        public async Task<Result<int>> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer mappedCustomer = _mapper.Map<Customer>(request.Customer);

            var resultCustomer = await _customerRepository.CreateAsync(mappedCustomer);
            if(resultCustomer != null)
                return await Result<int>.SuccessAsync("Customer Added");
            
            return await Result<int>.FailAsync("There is an Issue");
        }
    }
}
