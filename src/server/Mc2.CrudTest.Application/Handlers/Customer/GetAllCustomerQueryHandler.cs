using Mc2.CrudTest.Application.Commands.Customer;
using Mc2.CrudTest.Domain.IRepos.Customer;
using MediatR;

namespace Mc2.CrudTest.Application.Handlers.Customer;

public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, List<Domain.Entities.Customer>>
{
    private readonly ICustomerRepo _customerRepo;

    public GetAllCustomerQueryHandler(ICustomerRepo customerRepo) => _customerRepo = customerRepo;

    public async Task<List<Domain.Entities.Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return await _customerRepo.GetAllAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}