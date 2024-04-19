using Application.Interfaces.Repositories;
using Domain.Entities;
using Mc2.CrudTest.Presentation.Shared;
using MediatR;

namespace Application.Features.Customers.Queries.GetAll
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomersQuery, Result<GetAllCustomersResponse>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public async Task<Result<GetAllCustomersResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            List<Customer> customers = await _customerRepository.GetAllAsync();
            return await Result<GetAllCustomersResponse>.SuccessAsync(new GetAllCustomersResponse { Customers = customers });
        }
    }
}
