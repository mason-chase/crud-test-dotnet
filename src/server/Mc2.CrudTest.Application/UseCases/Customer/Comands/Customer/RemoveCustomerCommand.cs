using Mc2.CrudTest.Domain.IRepos.Customer;
using MediatR;

namespace Mc2.CrudTest.Application.UseCases.Customer.Comands.Customer;

public class RemoveCustomerCommand : IRequestHandler<RemoveCustomerReq>
{
    private readonly ICustomerRepo _customerRepo;

    public RemoveCustomerCommand(ICustomerRepo customerRepo) => _customerRepo = customerRepo;

    public async Task Handle(RemoveCustomerReq request, CancellationToken cancellationToken)
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