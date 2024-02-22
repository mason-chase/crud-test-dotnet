using AutoMapper;
using FluentValidation;
using Mc2.CrudTest.Presentation.Contracts.Customers;
using Mc2.CrudTest.Presentation.Domain.Customers;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Presentation.Application.Customers;

public class CustomerAppService(IMapper mapper, ICustomerRepository customerRepository) : ICustomerAppService
{
    private readonly IMapper _mapper = mapper;
    private readonly ICustomerRepository _customerRepository = customerRepository;
    public async Task CreateCustomer(CreateCustomerCommand command)
    {
        var customer = _mapper.Map<Customer>(command);

        await _customerRepository.CreateCustomer(customer);

    }
}
