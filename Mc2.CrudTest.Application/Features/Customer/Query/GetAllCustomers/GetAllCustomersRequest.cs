using Mc2.CrudTest.Domain.Models;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mc2.CrudTest.Application.Features.Customer.Query.GetAllCustomers;

public class GetAllCustomersRequest : IRequest<List<GetAllCustomersResponse>>
{
    public int Skip { get; set; }
    public int Limit { get; set; }
}