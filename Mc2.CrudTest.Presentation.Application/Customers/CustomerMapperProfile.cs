using AutoMapper;
using Mc2.CrudTest.Presentation.Contracts.Customers;
using Mc2.CrudTest.Presentation.Domain.Customers;

namespace Mc2.CrudTest.Presentation.Application.Customers
{
    public class CustomerMapperProfile : Profile
    {
        public CustomerMapperProfile()
        {
            CreateMap<Customer, CustomerCommand>();
            CreateMap<Customer, CustomerQuery>();
            CreateMap<CustomerCommand, Customer>();
        }

    }
}
