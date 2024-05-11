using Mc2.CrudTest.Presentation.DomainServices;
using Mc2.CrudTest.Presentation.Infrastructure;
using Mc2.CrudTest.Presentation.Shared.Queries;
using Mc2.CrudTest.Presentation.Shared.ReadModels;
using MediatR;

namespace Mc2.CrudTest.Presentation.Handlers;

public class GetCustomerByIdQueryHandler: INotification
{
    private readonly CustomerEventReadService  _readService;

    public GetCustomerByIdQueryHandler(CustomerEventReadService readService)
    {
        _readService = readService;
    }
    public async Task<IEnumerable<CustomerReadModel>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
       //Read from db and map to read Mpodel

       return await _readService.GetEventsForCustomerAsync(request.CustomerId);
    }
    
}