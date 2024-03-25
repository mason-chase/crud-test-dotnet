using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Domain.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PhoneNumbers;


namespace Mc2.CrudTest.Persistence.Services;

public class CustomerService : ICustomerService
{
    private readonly IMongoCollection<CustomerModel> _customerCollection;

    public CustomerService(IMongoDbContext mongoDbContext)
    {
        _customerCollection = mongoDbContext.GetCollection<CustomerModel>("customers");
    }

    public async Task ValidateCustomer(CustomerModel customerModel, CancellationToken cancellationToken)
    {
        await CheckUniqueCustomer(customerModel.FirstName, customerModel.LastName, customerModel.DateOfBirth, cancellationToken);
        await CheckEmailUnique(customerModel.Email, cancellationToken);
        await CheckValidPhoneNumber(customerModel.PhoneNumber, cancellationToken);
    }

    private async Task CheckUniqueCustomer(string firstName, string lastName, DateTime dateOfBirth, CancellationToken cancellationToken)
    {
        try
        {
            bool isCustomerExist = await _customerCollection
                .AsQueryable()
                .Where(a => a.FirstName == firstName && a.LastName == lastName && a.DateOfBirth == dateOfBirth)
                .AnyAsync(cancellationToken);

            if (isCustomerExist)
                throw new Exception("Customer should have unique First Name, Last Name and Birth Date");
        }
        catch (Exception ex)
        {
            throw new Exception("Operation failed");
        }
    }

    private async Task CheckEmailUnique(string email, CancellationToken cancellationToken)
    {
        try
        {
            bool isEmailExists = await _customerCollection
                .AsQueryable()
                .Where(a => a.Email == email)
                .AnyAsync(cancellationToken);

            if (isEmailExists)
                throw new Exception("Email should be unique");
        }
        catch (Exception ex)
        {
            throw new Exception("Operation failed");
        }
    }

    private async Task CheckValidPhoneNumber(string phoneNumber, CancellationToken cancellationToken)
    {
        var phoneNumberUtil = PhoneNumberUtil.GetInstance();
        
        try
        {
            var parsedNumber = phoneNumberUtil.Parse(phoneNumber, null);
            if (!phoneNumberUtil.IsValidNumber(parsedNumber))
            {
                throw new Exception("Phone number is not valid");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Operation failed");
        }
    }
}