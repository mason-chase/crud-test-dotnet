using Application.Customers.Commands.CreateCustomer;
using Application.Customers.Commands.UpdateCustomer;
using Application.Customers.Queries.GetCustomerById;
using AutoMapper;
using Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.MappingProfiles;

public class CustomerMappings : Profile
{
    public CustomerMappings()
    {
        CreateMap<CreateCustomerCommand, Customer>();
        CreateMap<UpdateCustomerCommand, Customer>();
        CreateMap<Customer, CustomerResponse>();
    }
}