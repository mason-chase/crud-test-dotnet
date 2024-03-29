using Mc2.CrudTest.Domain.IRepos.Customer;
using MediatR;

namespace Mc2.CrudTest.Application.UseCases.Customer.Queries.Customer;

public class GetAllCustomerQuery : IRequestHandler<GetAllCustomerReq, List<Domain.Entities.Customer>>
{
    private readonly ICustomerRepo _customerRepo;

    public GetAllCustomerQuery(ICustomerRepo customerRepo) => _customerRepo = customerRepo;

    public async Task<List<Domain.Entities.Customer>> Handle(GetAllCustomerReq request, CancellationToken cancellationToken)
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