using Application.Commom.Models;
using Application.DTOs.Customer.Entities;
using MediatR;

namespace Application.Entities.Customer.Requests.Queries;

public class GetCustomersQuery : IRequest<Result<List<CustomerListDto>>>
{
    public CustomerSearchDto CustomerSearchDto { get; set; }
}
