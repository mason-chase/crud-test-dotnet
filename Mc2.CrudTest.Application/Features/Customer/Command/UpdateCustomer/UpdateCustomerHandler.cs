using AutoMapper;
using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Domain.Models;
using MediatR;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;
using ReturnDocument = MongoDB.Driver.ReturnDocument;

namespace Mc2.CrudTest.Application.Features.Customer.Command.UpdateCustomer;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, CustomerModel>
{
    private readonly IMongoCollection<CustomerModel> _customerCollection;
    private readonly IMapper _mapper;

    public UpdateCustomerHandler(IMongoDbContext mongoDbContext, IMapper mapper)
    {
        _customerCollection = mongoDbContext.GetCollection<CustomerModel>("customers");
        _mapper = mapper;
    }

    public async  Task<CustomerModel> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        var updateModel = _mapper.Map<CustomerModel>(request);

        var filter = Builders<CustomerModel>.Filter.Eq(a => a.Id, request.Id);
        
        var options = new FindOneAndReplaceOptions<CustomerModel, CustomerModel>
        {
            ReturnDocument = ReturnDocument.After
        };

        var updatedModel = await _customerCollection.FindOneAndReplaceAsync(filter, updateModel, options, cancellationToken);

        return updatedModel;
    }
}