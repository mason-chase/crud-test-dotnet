using Application.DTOs.Customer.Entities;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        #region Customer
        CreateMap<Customer, CreateCustomerDto>()
            .ReverseMap();
        CreateMap<Customer, UpdateCustomerDto>()
            .ReverseMap();
        CreateMap<Customer,CustomerListDto>()
            .ForMember(x => x.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
            .ReverseMap();
        #endregion
    }
}


