using Mc2.CrudTest.Modules.Customers.Domain.CustomerAggregate.GetCustomer;
using Mc2.CrudTest.Modules.Customers.Domain.Exceptions;
using Mc2.CrudTest.Shared.BuildingBlocks.CQRS;
using Mc2.CrudTest.Shared.BuildingBlocks.Stores;

namespace Mc2.CrudTest.Modules.Customers.Application.QueryHandlers;

public class GetCustomerHandler : IQueryHandler<GetCustomerQuery, CustomerDto>
{
    private readonly IReadModelRepository<CustomerDto> _readModelRepository;

    public GetCustomerHandler(IReadModelRepository<CustomerDto> readModelRepository)
    {
        _readModelRepository = readModelRepository;
    }

    public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        CustomerDto? customer = await _readModelRepository.GetByIdAsync(request.CustomerId, cancellationToken);
        if (customer == null)
            throw new CustomerNotFoundException(request.CustomerId);

        return customer;
    }
}