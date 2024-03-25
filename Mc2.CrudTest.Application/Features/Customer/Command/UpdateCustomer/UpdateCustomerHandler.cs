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
    private readonly ICustomerService _customerService;

    public UpdateCustomerHandler(IMongoDbContext mongoDbContext, IMapper mapper, ICustomerService customerService)
    {
        _customerCollection = mongoDbContext.GetCollection<CustomerModel>("customers");
        _mapper = mapper;
        _customerService = customerService;
    }

    public async Task<CustomerModel> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customerModel = _mapper.Map<CustomerModel>(request);

        try
        {
            await _customerService.ValidateCustomer(customerModel, cancellationToken);
            var filter = Builders<CustomerModel>.Filter.Eq(a => a.Id, request.Id);
            await _customerCollection.FindOneAndReplaceAsync(filter, customerModel, null, cancellationToken);
        }
        catch (Exception ex)
        {
        }

        return customerModel;
    }
}