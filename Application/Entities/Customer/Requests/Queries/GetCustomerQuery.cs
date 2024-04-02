using Application.Commom.Models;
using Application.DTOs.Customer.Entities;
using MediatR;

namespace Application.Entities.Customer.Requests.Queries;

public class GetCustomerQuery : IRequest<Result<UpdateCustomerDto>>
{
    public int Id { get; set; }
}
