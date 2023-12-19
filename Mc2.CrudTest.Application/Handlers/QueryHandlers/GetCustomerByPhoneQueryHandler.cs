using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Application.Common.Models;
using Mc2.CrudTest.Application.Queries;
using MediatR;

namespace Mc2.CrudTest.Application.Handlers.QueryHandlers;

public class GetCustomerByPhoneQueryHandler : IRequestHandler<GetCustomerByPhoneQuery, Customer?>
{
    private readonly ICustomersRepository _customersRepository;

    public GetCustomerByPhoneQueryHandler(ICustomersRepository customersRepository)
    {
        _customersRepository = customersRepository;
    }

    public async Task<Customer?> Handle(GetCustomerByPhoneQuery request, CancellationToken cancellationToken)
    {
        var result = await _customersRepository.GetCustomerByPhoneAsync(request.PhoneNumber);
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