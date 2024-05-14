using Mc2.CrudTest.Presentation.DomainServices;
using Mc2.CrudTest.Presentation.Infrastructure;
using Mc2.CrudTest.Presentation.Shared.Entities;
using Mc2.CrudTest.Presentation.Shared.Queries;
using Mc2.CrudTest.Presentation.Shared.ReadModels;
using MediatR;

namespace Mc2.CrudTest.Presentation.Handlers;

public class GetCustomerByIdQueryHandler: INotification
{
    private readonly ICustomerService  _readService;

    public GetCustomerByIdQueryHandler(ICustomerService readService)
    {
        _readService = readService;
    }
    public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
       //Read from db and map to read Mpodel

       return await _readService.GetCustomer(request.CustomerId);
    }
    
}