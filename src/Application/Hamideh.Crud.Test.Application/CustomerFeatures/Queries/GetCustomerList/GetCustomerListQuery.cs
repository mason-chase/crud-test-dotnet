using MediatR;

namespace Hamideh.Crud.Test.Application.CustomerFeatures.Queries.GetCustomerList
{
    public record GetCustomerListQuery : IRequest<List<GetCustomerListQueryResponse>>
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
