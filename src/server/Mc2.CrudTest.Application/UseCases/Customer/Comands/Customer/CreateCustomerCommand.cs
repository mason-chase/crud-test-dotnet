using Mc2.CrudTest.Domain.IRepos.Customer;
using MediatR;

namespace Mc2.CrudTest.Application.UseCases.Customer.Comands.Customer;

public class CreateCustomerCommand : IRequestHandler<CreateCustomerReq>
{
    private readonly ICustomerRepo _customerRepo;

    public CreateCustomerCommand(ICustomerRepo customerRepo) => _customerRepo = customerRepo;
    public async Task Handle(CreateCustomerReq request, CancellationToken cancellationToken)
    {
        try
        {
            await _customerRepo.AddAsync(new Domain.Entities.Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                BankAccountNumber = request.BankAccountNumber
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}