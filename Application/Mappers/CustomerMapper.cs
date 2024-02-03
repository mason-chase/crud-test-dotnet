using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {

            CreateMap<Customer, CustomerDTO>();

            CreateMap<CreateCustomerDTO, Customer>();

            CreateMap<UpdateCustomerDTO, Customer>();
        }
    }
}
