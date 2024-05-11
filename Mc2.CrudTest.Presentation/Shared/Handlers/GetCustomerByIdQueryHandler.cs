using Mc2.CrudTest.Presentation.Shared.Queries;
using Mc2.CrudTest.Presentation.Shared.ReadModels;
using MediatR;

namespace Mc2.CrudTest.Presentation.Shared.Handlers;

public class GetCustomerByIdQueryHandler: IRequestHandler<GetCustomerByIdQuery, CustomerReadModel>
{
    private IStore _store;
    public GetCustomerByIdQueryHandler(IStore store)
    {
        _store = store;
    }
    public async Task<CustomerReadModel> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
       //Read from db and map to read Mpodel

        return new CustomerReadModel();
    }
    
}