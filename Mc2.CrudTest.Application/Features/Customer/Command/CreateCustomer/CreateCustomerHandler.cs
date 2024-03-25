using AutoMapper;
using Mc2.CrudTest.Application.Features.Customer.Query.GetAllCustomers;
using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Domain.Models;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mc2.CrudTest.Application.Features.Customer.Command.CreateCustomer;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
{
    private readonly IMongoCollection<CreateCustomerRequest> _customerCollection;
    private readonly IMapper _mapper;

    public CreateCustomerHandler(IMongoDbContext mongoDbContext, IMapper mapper)
    {
        _customerCollection = mongoDbContext.GetCollection<CreateCustomerRequest>("customers");
        _mapper = mapper;
    }

    public async  Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        CreateCustomerResponse responseModel = _mapper.Map<CreateCustomerResponse>(request);
        responseModel.IsDeleted = false;
        responseModel.CreatedAt = DateTime.UtcNow;
        responseModel.Id = ObjectId.GenerateNewId().ToString();
        
        await _customerCollection.InsertOneAsync(request, null, cancellationToken);

        return responseModel;
    }
}