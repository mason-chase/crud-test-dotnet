using Mc2.CrudTest.Application.Commands.Customer;
using Mc2.CrudTest.Domain.IRepos.Customer;
using MediatR;

namespace Mc2.CrudTest.Application.Handlers.Customer;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Domain.Entities.Customer>
{
    private readonly ICustomerRepo _customerRepo;

    public GetCustomerByIdQueryHandler(ICustomerRepo customerRepo) => _customerRepo = customerRepo;

    public async Task<Domain.Entities.Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
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