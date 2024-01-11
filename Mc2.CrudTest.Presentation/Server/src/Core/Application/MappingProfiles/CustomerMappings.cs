using Application.Customers.Commands.CreateCustomer;
using AutoMapper;
using Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.MappingProfiles;

public class CustomerMappings : Profile
{
    public CustomerMappings()
    {
        CreateMap<CreateCustomerCommand, Customer>();
    }
}