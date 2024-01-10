using Ardalis.Result;
using Mc2.CrudTest.Application.Contract.Customers.Mappers;
using Mc2.CrudTest.Application.Contract.Customers.Queries;
using Mc2.CrudTest.Application.Contract.Customers.Responses;
using Mc2.CrudTest.Domain.Contract.Customers;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.QueryHandler;

internal class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Result<GetCustomerByIdResponse>>
{
    private readonly ICustomerReadOnlyRepository _repository;
    private readonly IGetCustomerByIdMapper _mapper;

    public GetCustomerByIdQueryHandler(
        ICustomerReadOnlyRepository repository,
        IGetCustomerByIdMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<GetCustomerByIdResponse>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Id);

        if (customer == null)
        {
            return Result<GetCustomerByIdResponse>.Error("Customer does not exist.");
        }

        return Result<GetCustomerByIdResponse>.Success(_mapper.Map(customer));
    }
}
