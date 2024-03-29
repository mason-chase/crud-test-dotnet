using Mc2.CrudTest.Application.Commands.Customer;
using Mc2.CrudTest.Contracts;
using Mc2.CrudTest.Domain.IRepos.Customer;
using MediatR;

namespace Mc2.CrudTest.Application.Handlers.Customer;

public class RemoveCustomerCommandHandler : IRequestHandler<RemoveCustomerCommand>
{
    private readonly ICustomerRepo _customerRepo;
    private readonly ILoggerAdapter<RemoveCustomerCommandHandler> _logger;
    public RemoveCustomerCommandHandler(ICustomerRepo customerRepo, ILoggerAdapter<RemoveCustomerCommandHandler> logger)
    {
        _customerRepo = customerRepo;
        _logger = logger;
    }

    public async Task Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Domain.Entities.Customer customerToDelete = await _customerRepo.GetByIdAsync(request.CustomerId);

            await _customerRepo.DeleteAsync(customerToDelete);
        }
        catch (Exception e)
        {
            _logger.LogError($"Remove Customer Has Error --> {e.Message}");
            throw;
        }
    }
}