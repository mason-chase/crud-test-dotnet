using Application.Commom.Models;
using MediatR;

namespace Application.Entities.Customer.Requests.Commands;

public class DeleteCustomerCommand : IRequest<Result<bool>>
{
    public int Id { get; set; }
}
