using MediatR;

namespace Hamideh.Crud.Test.Application.CustomerFeatures.Command.DeleteCustomer
{
    public record DeleteCustomerCommand : IRequest<DeleteCustomerCommandResponse>
    {
        public int Id { get; set; }

    }
}
