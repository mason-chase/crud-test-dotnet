using Hamideh.Crud.Test.Domain;
using MediatR;

namespace Hamideh.Crud.Test.Application.CustomerFeatures.Queries.GetCustomerList
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<GetCustomerListQueryResponse>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerListQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<List<GetCustomerListQueryResponse>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var customerList = await _customerRepository.GetCustomerListAsync();
            if (customerList == null) return [];

            //TODO I could use mapster
            return customerList.Select(customer => new GetCustomerListQueryResponse
            {
                Id = customer.Id,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber
            }
            ).ToList();
        }
    }
}
