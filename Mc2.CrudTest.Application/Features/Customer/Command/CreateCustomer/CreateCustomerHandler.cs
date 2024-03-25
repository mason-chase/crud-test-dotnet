using AutoMapper;
using Mc2.CrudTest.Application.Features.Customer.Query.GetAllCustomers;
using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Domain.Models;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mc2.CrudTest.Application.Features.Customer.Command.CreateCustomer;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CustomerModel>
{
    private readonly IMongoCollection<CustomerModel> _customerCollection;
    private readonly IMapper _mapper;

    public CreateCustomerHandler(IMongoDbContext mongoDbContext, IMapper mapper)
    {
        _customerCollection = mongoDbContext.GetCollection<CustomerModel>("customers");
        _mapper = mapper;
    }

    public async  Task<CustomerModel> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        CustomerModel responseModel = _mapper.Map<CustomerModel>(request);
        responseModel.IsDeleted = false;
        responseModel.CreatedAt = DateTime.UtcNow;
        responseModel.Id = ObjectId.GenerateNewId().ToString();
        
        await _customerCollection.InsertOneAsync(responseModel, null, cancellationToken);

        return responseModel;
    }
}