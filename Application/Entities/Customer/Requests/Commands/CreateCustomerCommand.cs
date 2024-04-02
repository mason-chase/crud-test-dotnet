using Application.Commom.Models;
using Application.DTOs.Customer.Entities;
using MediatR;

namespace Application.Entities.Customer.Requests.Commands;

public class CreateCustomerCommand : IRequest<Result<int>>
{
    public CreateCustomerDto CreateCustomerDto { get; set; } = null!;
}
