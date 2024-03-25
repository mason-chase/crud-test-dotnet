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
    private readonly ICustomerService _customerService;

    public CreateCustomerHandler(IMongoDbContext mongoDbContext, IMapper mapper, ICustomerService customerService)
    {
        _customerCollection = mongoDbContext.GetCollection<CustomerModel>("customers");
        _mapper = mapper;
    }

    public async  Task<CustomerModel> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        CustomerModel customerModel = _mapper.Map<CustomerModel>(request);

        try
        {
            await _customerService.ValidateCustomer(customerModel, cancellationToken);
            customerModel.IsDeleted = false;
            customerModel.CreatedAt = DateTime.UtcNow;
            customerModel.Id = ObjectId.GenerateNewId().ToString();
            await _customerCollection.InsertOneAsync(customerModel, null, cancellationToken);
        }
        catch (Exception ex)
        {
            throw;
        }
        
        return customerModel;
    }
}