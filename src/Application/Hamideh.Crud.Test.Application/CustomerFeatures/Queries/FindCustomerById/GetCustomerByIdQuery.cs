using MediatR;

namespace Hamideh.Crud.Test.Application.CustomerFeatures.Queries.FindCustomerById
{
    public class GetCustomerByIdQuery : IRequest<GetCustomerByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
