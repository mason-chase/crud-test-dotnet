using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Domain.Models;
using MediatR;
using MongoDB.Driver;

namespace Mc2.CrudTest.Application.Features.Customer.Query.GetCustomerById;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdRequest, CustomerModel>
{
    private readonly IMongoCollection<CustomerModel> _customerCollection;

    public GetCustomerByIdHandler(IMongoDbContext mongoDbContext)
    {
        _customerCollection = mongoDbContext.GetCollection<CustomerModel>("customers");
    }
    
    public async Task<CustomerModel> Handle(GetCustomerByIdRequest request, CancellationToken cancellationToken)
    {
        var customerModel = await _customerCollection.Find(a => a.Id == request.id & !a.IsDeleted).FirstOrDefaultAsync(cancellationToken);

        return customerModel;
    }
}