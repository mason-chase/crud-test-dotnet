using AutoMapper;
using Mc2.CrudTest.Presentation.Contracts.Customers;
using Mc2.CrudTest.Presentation.Domain.Customers;

namespace Mc2.CrudTest.Presentation.Application.Customers;

public class CustomerAppService : ICustomerAppService
{
    private readonly IMapper _mapper;
    private ICustomerRepository _customerRepository;

    public CustomerAppService(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task CreateCustomer(CreateCustomerCommand command)
    {
        var customer = _mapper.Map<Customer>(command);

        await _customerRepository.CreateCustomer(customer);

    }
}
