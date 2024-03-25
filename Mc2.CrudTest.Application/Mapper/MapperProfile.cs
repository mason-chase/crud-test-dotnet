using AutoMapper;
using Mc2.CrudTest.Application.Features.Customer.Command.CreateCustomer;

namespace Mc2.CrudTest.Application.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<CreateCustomerRequest, CreateCustomerResponse>().ReverseMap();
    }
    
}