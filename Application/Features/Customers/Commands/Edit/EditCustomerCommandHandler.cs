using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Mc2.CrudTest.Presentation.Shared;
using MediatR;

namespace Application.Features.Customers.Commands.Edit
{
    public class EditCustomerCommandHandler : IRequestHandler<EditCustomerCommand, Result<int>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public EditCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }
        public async Task<Result<int>> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer mappedCustomer = _mapper.Map<Customer>(request.Customer);

            var resultCustomer = await _customerRepository.UpdateAsync(mappedCustomer);
            if (resultCustomer != null)
                return await Result<int>.SuccessAsync("Customer Updated");

            return await Result<int>.FailAsync("There is an Issue");
        }
    }
}
