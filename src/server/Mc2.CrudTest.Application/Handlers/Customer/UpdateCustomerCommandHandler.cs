using Mc2.CrudTest.Application.Commands.Customer;
using Mc2.CrudTest.Domain.IRepos.Customer;
using MediatR;

namespace Mc2.CrudTest.Application.Handlers.Customer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
{
    private readonly ICustomerRepo _customerRepo;

    public UpdateCustomerCommandHandler(ICustomerRepo customerRepo) => _customerRepo = customerRepo;

    public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existingCustomer = await _customerRepo.GetByIdAsync(request.CustomerId);

            if (existingCustomer is null)
                throw new Exception("Customer Not Found");

            existingCustomer.PhoneNumber = request.PhoneNumber;
            existingCustomer.Email = request.Email;
            existingCustomer.BankAccountNumber = request.BankAccountNumber;

            await _customerRepo.UpdateAsync(existingCustomer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}