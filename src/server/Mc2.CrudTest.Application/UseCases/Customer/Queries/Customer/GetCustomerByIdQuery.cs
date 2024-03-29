using Mc2.CrudTest.Domain.IRepos.Customer;
using MediatR;

namespace Mc2.CrudTest.Application.UseCases.Customer.Queries.Customer;

public class GetCustomerByIdQuery : IRequestHandler<GetCustomerByIdReq, Domain.Entities.Customer>
{
    private readonly ICustomerRepo _customerRepo;

    public GetCustomerByIdQuery(ICustomerRepo customerRepo) => _customerRepo = customerRepo;

    public async Task<Domain.Entities.Customer> Handle(GetCustomerByIdReq request, CancellationToken cancellationToken)
    {
        try
        {
            return await _customerRepo.GetByIdAsync(request.CustomerId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}