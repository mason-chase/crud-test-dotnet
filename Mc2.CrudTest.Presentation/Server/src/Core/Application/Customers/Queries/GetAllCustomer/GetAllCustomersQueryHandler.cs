using Application.Customers.Queries.GetCustomerById;
using AutoMapper;
using Azure.Core;
using CQRS.NET;
using Domain.Abstractions;
using MediatR;

namespace Application.Customers.Queries.GetAllCustomer;

    public class GetAllCustomersQueryHandler : IQueryHandler<GetAllCustomersQuery,List< CustomerResponse>>,
        IRequestHandler<GetAllCustomersQuery,List< CustomerResponse>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }


      

        public async Task<List<CustomerResponse>> HandleAsync(GetAllCustomersQuery query)
        {
            var customers = await _customerRepository.GetAllAsync();

            var customerResponses = _mapper.Map<List<CustomerResponse>>(customers);

            return customerResponses;
        }

        public async Task<List<CustomerResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync();

            var customerResponses = _mapper.Map<List<CustomerResponse>>(customers);

            return customerResponses;
        }
    }