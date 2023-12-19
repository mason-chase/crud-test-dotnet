using ClassLibrary1Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.Repository;

public class CustomersRepository : ICustomersRepository
{
    private readonly EfDbContext _db;

    public CustomersRepository(EfDbContext db)
    {
        _db = db;
    }

    public async Task<Customer?> GetCustomerByIdAsync(long customerId)
        => await _db.Customers.FirstOrDefaultAsync(x => x.Id == customerId && x.IsRemoved == false);
    

    public async Task<Customer?> GetCustomerByPhoneAsync(string phone)
        => await _db.Customers.FirstOrDefaultAsync(x => x.PhoneNumber.Equals( phone) && x.IsRemoved == false);

    public async Task<long> AddCustomerAsync(Customer customer)
    {
        await _db.AddAsync(customer);
        return await _db.SaveChangesAsync() > 0 ? customer.Id : 0;
    }

    public async Task<bool> UpdateCustomerAsync(Customer customer)
    {
        var existingCustomer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == customer.Id && x.IsRemoved == false);
        if (existingCustomer is null)
        {
            return false;
        }

        existingCustomer.PhoneNumber = customer.PhoneNumber;
        existingCustomer.Email = customer.Email;
        existingCustomer.FirstName = customer.FirstName;
        existingCustomer.LastName = customer.LastName;
        existingCustomer.BankAccountNumber = customer.BankAccountNumber;
        existingCustomer.DateOfBirth = customer.DateOfBirth;
        return await _db.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveCustomerAsync(long id)
    {
        var existingCustomer = await _db.Customers.FirstOrDefaultAsync(x => x.Id == id);
        if (existingCustomer is null)
        {
            return false;
        }
        existingCustomer.IsRemoved = true;
        return await _db.SaveChangesAsync() > 0;
    }
}