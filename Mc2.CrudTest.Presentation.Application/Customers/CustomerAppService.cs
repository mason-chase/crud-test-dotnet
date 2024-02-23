using AutoMapper;
using FluentValidation;
using Mc2.CrudTest.Presentation.Contracts.Customers;
using Mc2.CrudTest.Presentation.Domain.Customers;
using System.Linq.Expressions;

namespace Mc2.CrudTest.Presentation.Application.Customers;

public class CustomerAppService(IMapper mapper, ICustomerRepository customerRepository, IValidator<CustomerCommand> validator) : ICustomerAppService
{
    private readonly IMapper _mapper = mapper;
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly IValidator<CustomerCommand> _validator=validator;
    public async Task CreateCustomer(CustomerCommand command)
    {
        var validation = _validator.Validate(command);
        if (validation.IsValid)
        {
            var customer = _mapper.Map<Customer>(command);
            await _customerRepository.CreateCustomer(customer);
        }
        else
        {
            throw new ValidationException(validation.Errors);
        }
        
    }
    public async Task<List<CustomerQuery>> GetCustomers()
    {
        var customers = _mapper.Map<List<CustomerQuery>>(await _customerRepository.GetAll());

        return customers;
    }
    public async Task DeleteCustomer(int customerId)
    {
        var customer = await _customerRepository.GetById(customerId);
        await _customerRepository.Delete(customer);
    }
    public async Task UpdateCustomer(int customerId, CustomerCommand command)
    {
        var validation = _validator.Validate(command);
        if (validation.IsValid)
        {
            var customer = await _customerRepository.GetById(customerId);
            customer.Update(command.FirstName, command.LastName, command.DateOfBirth, command.PhoneNumber, command.Email, command.BankAccountNumber);
            await _customerRepository.Update(customer);
        }
        else
        {
            throw new ValidationException(validation.Errors);
        }
        
    }
}
