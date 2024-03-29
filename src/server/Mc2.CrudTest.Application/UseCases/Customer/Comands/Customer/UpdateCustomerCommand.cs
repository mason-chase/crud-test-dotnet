using Mc2.CrudTest.Domain.IRepos.Customer;
using MediatR;

namespace Mc2.CrudTest.Application.UseCases.Customer.Comands.Customer;

public class UpdateCustomerCommand : IRequestHandler<UpdateCustomerReq, Domain.Entities.Customer>
{
    private readonly ICustomerRepo _customerRepo;

    public UpdateCustomerCommand(ICustomerRepo customerRepo) => _customerRepo = customerRepo;

    public async Task<Domain.Entities.Customer> Handle(UpdateCustomerReq request, CancellationToken cancellationToken)
    {
        try
        {
            Domain.Entities.Customer customer = await _customerRepo.UpdateAsync(new Domain.Entities.Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                BankAccountNumber = request.BankAccountNumber,
            });

            return customer;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}