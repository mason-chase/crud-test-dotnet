using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Application.Common.Models;
using Mc2.CrudTest.Application.Queries;
using MediatR;

namespace Mc2.CrudTest.Application.Handlers.QueryHandlers;

public class GetCustomerByIdQueryHandler: IRequestHandler<GetCustomerByIdQuery, Customer?>
{
    private readonly ICustomersRepository _customersRepository;

    public GetCustomerByIdQueryHandler(ICustomersRepository customersRepository)
    {
        _customersRepository = customersRepository;
    }

    public async Task<Customer?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _customersRepository.GetCustomerByIdAsync(request.Id);
        if (result != null)
            return new Customer()
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                PhoneNumber = result.PhoneNumber,
                BankAccountNumber = result.BankAccountNumber,
                DateOfBirth = result.DateOfBirth,
                Email = result.Email
            };
        return null;
    }
}