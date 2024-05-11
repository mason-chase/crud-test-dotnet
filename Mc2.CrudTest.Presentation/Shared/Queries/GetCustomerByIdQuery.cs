using Mc2.CrudTest.Presentation.Shared.ReadModels;
using MediatR;

namespace Mc2.CrudTest.Presentation.Shared.Queries;

public class GetCustomerByIdQuery : IRequest<CustomerReadModel>

{
    public Guid CustomerId { get; set; }
}