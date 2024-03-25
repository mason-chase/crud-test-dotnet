using AutoMapper;
using Mc2.CrudTest.Application.Features.Customer.Command.CreateCustomer;
using Mc2.CrudTest.Application.Features.Customer.Command.UpdateCustomer;
using Mc2.CrudTest.Application.Features.Customer.Query.GetAllCustomers;
using Mc2.CrudTest.Application.Features.Customer.Query.GetCustomerById;
using Mc2.CrudTest.Domain.Models;

namespace Mc2.CrudTest.Application.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<CreateCustomerRequest, CustomerModel>().ReverseMap();
        CreateMap<GetAllCustomersRequest, CustomerModel>().ReverseMap();
        CreateMap<GetCustomerByIdRequest, CustomerModel>().ReverseMap();
        CreateMap<UpdateCustomerRequest, CustomerModel>().ReverseMap();

    }
    
}