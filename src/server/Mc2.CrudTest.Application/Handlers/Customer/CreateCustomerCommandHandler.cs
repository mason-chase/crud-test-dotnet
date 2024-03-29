using Mc2.CrudTest.Application.Commands.Customer;
using Mc2.CrudTest.Domain.IRepos.Customer;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mc2.CrudTest.Application.Handlers.Customer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepo _customerRepo;

    public CreateCustomerCommandHandler(ICustomerRepo customerRepo) => _customerRepo = customerRepo;
    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
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