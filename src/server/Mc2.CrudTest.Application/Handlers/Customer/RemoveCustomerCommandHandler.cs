using Mc2.CrudTest.Application.Commands.Customer;
using Mc2.CrudTest.Domain.IRepos.Customer;
using MediatR;

namespace Mc2.CrudTest.Application.Handlers.Customer;

public class RemoveCustomerCommandHandler : IRequestHandler<RemoveCustomerCommand>
{
    private readonly ICustomerRepo _customerRepo;

    public RemoveCustomerCommandHandler(ICustomerRepo customerRepo) => _customerRepo = customerRepo;

    public async Task Handle(RemoveCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Domain.Entities.Customer customerToDelete = await _customerRepo.GetByIdAsync(request.CustomerId);

            await _customerRepo.DeleteAsync(customerToDelete);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}