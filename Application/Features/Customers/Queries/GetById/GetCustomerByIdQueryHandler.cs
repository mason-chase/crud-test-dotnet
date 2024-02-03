using Application.Interfaces.Repositories;
using Domain.Entities;
using Mc2.CrudTest.Presentation.Shared;
using MediatR;

namespace Application.Features.Customers.Queries.GetById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Result<GetCustomerByIdResponse>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public async Task<Result<GetCustomerByIdResponse>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {

            Customer? customer = await _customerRepository.GetAsync(request.Id);
            if(customer == null)
            {
                return await Result<GetCustomerByIdResponse>.FailAsync();
            }
            return await Result<GetCustomerByIdResponse>.SuccessAsync(new GetCustomerByIdResponse { Customer = customer });
        }
    }
}
