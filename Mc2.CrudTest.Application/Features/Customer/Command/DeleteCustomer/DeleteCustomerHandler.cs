using AutoMapper;
using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Domain.Models;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Mc2.CrudTest.Application.Features.Customer.Command.DeleteCustomer;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest, CustomerModel>
{
    private readonly IMongoCollection<CustomerModel> _customerCollection;

    public DeleteCustomerHandler(IMongoDbContext mongoDbContext)
    {
        _customerCollection = mongoDbContext.GetCollection<CustomerModel>("customers");
    }

    public async Task<CustomerModel> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        var filter = Builders<CustomerModel>.Filter.Eq(a => a.Id, request.id);
        var update = Builders<CustomerModel>.Update.Set(a => a.IsDeleted, true).Set(a => a.UpdatedAt, DateTime.UtcNow);
        var options = new FindOneAndUpdateOptions<CustomerModel>
        {
            ReturnDocument = ReturnDocument.After
        };

        var deletedCustomerModel = await _customerCollection.FindOneAndUpdateAsync(filter, update, options, cancellationToken);
        return deletedCustomerModel;
    }
}