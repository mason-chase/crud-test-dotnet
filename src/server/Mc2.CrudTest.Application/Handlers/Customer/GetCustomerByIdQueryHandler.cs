using Mc2.CrudTest.Application.Commands.Customer;
using Mc2.CrudTest.Contracts;
using Mc2.CrudTest.Domain.IRepos.Customer;
using MediatR;

namespace Mc2.CrudTest.Application.Handlers.Customer;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Domain.Entities.Customer>
{
    private readonly ICustomerRepo _customerRepo;
    private readonly ILoggerAdapter<GetCustomerByIdQueryHandler> _logger;
    public GetCustomerByIdQueryHandler(ICustomerRepo customerRepo, ILoggerAdapter<GetCustomerByIdQueryHandler> logger)
    {
        _customerRepo = customerRepo;
        _logger = logger;
    }

    public async Task<Domain.Entities.Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _customerRepo.GetByIdAsync(request.CustomerId);
        }
        catch (Exception e)
        {
            _logger.LogError($"Get Customer By ID Has error --> {e.Message}");
            throw;
        }
    }
}