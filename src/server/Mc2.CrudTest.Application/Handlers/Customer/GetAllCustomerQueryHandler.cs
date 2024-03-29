using Mc2.CrudTest.Application.Commands.Customer;
using Mc2.CrudTest.Contracts;
using Mc2.CrudTest.Domain.IRepos.Customer;
using MediatR;

namespace Mc2.CrudTest.Application.Handlers.Customer;

public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, List<Domain.Entities.Customer>>
{
    private readonly ICustomerRepo _customerRepo;
    private readonly ILoggerAdapter<GetAllCustomerQueryHandler> _logger;

    public GetAllCustomerQueryHandler(ICustomerRepo customerRepo, ILoggerAdapter<GetAllCustomerQueryHandler> logger)
    {
        _customerRepo = customerRepo;
        _logger = logger;
    }

    public async Task<List<Domain.Entities.Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _customerRepo.GetAllAsync();
        }
        catch (Exception e)
        {
            _logger.LogError($"Get All The Customer Has Error --> ${e.Message}");
            throw;
        }
    }
}