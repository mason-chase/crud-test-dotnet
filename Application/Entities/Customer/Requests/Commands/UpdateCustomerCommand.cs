using Application.Commom.Models;
using Application.DTOs.Customer.Entities;
using MediatR;

namespace Application.Entities.Customer.Requests.Commands;

public class UpdateCustomerCommand : IRequest<Result<bool>>
{
    public UpdateCustomerDto UpdateCustomerDto { get; set; } = null!;
}