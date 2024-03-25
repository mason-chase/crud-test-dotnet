using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Domain.Models;
using MediatR;
using Microsoft.VisualBasic.CompilerServices;
using MongoDB.Driver;

namespace Mc2.CrudTest.Application.Features.Customer.Query.GetAllCustomers;

public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersRequest, List<CustomerModel>>
{
    private readonly IMongoCollection<CustomerModel> _customerCollection;

    public GetAllCustomersHandler(IMongoDbContext mongoDbContext)
    {
        _customerCollection = mongoDbContext.GetCollection<CustomerModel>("customers");

    }
    
    public async Task<List<CustomerModel>> Handle(GetAllCustomersRequest request, CancellationToken cancellationToken)
    {
        var customerModelList = await _customerCollection.Find(a => !a.IsDeleted).ToListAsync(cancellationToken);
        
        return customerModelList;
    }
}