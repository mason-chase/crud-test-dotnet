using Application.Contracts.Persistence;
using Application.DTOs.Customer;
using Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerListDto>> GetAllCustomersAsync()
        {
            var customers = await _context.Customers.Where(c => !c.IsRemoved).ToListAsync();

            var returnDto = customers.Select(s => new CustomerListDto
            {
                Id = s.Id,
                InsertTime = s.InsertTime.ToString("yyyy-MM-dd HH:mm"),
                FirstName = s.FirstName,
                LastName = s.LastName,
                PhoneNumber = s.PhoneNumber.ToString(),
                Email = s.Email,
                BankAccountNumber = s.BankAccountNumber,
                DateOfBirth = s.DateOfBirth.ToString("yyyy-MM-dd"),
            }).ToList();

            return returnDto;
        }

        public async Task<CustomerDetailDto> GetCustomerByIdAsync(Guid id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id && !c.IsRemoved);

            if (customer is null)
                return null;

            var returnDto = new CustomerDetailDto
            {
                InsertTime = customer.InsertTime.ToString("yyyy-MM-dd HH:mm"),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber.ToString(),
                Email = customer.Email,
                BankAccountNumber = customer.BankAccountNumber,
                DateOfBirth = customer.DateOfBirth.ToString("yyyy-MM-dd"),
            };

            return returnDto;
        }

        public async Task<Customer> CreateCustomerAsync(CustomerCreateUpdateDto dto)
        {
            var customer = new Customer
            {
                InsertTime = DateTime.UtcNow,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                BankAccountNumber = dto.BankAccountNumber,
                DateOfBirth = dto.DateOfBirth,
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomerAsync(Guid id, CustomerCreateUpdateDto updatedCustomer)
        {
            var existingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id && !c.IsRemoved);
            if (existingCustomer is null)
                return null;

            existingCustomer.FirstName = updatedCustomer.FirstName;
            existingCustomer.LastName = updatedCustomer.LastName;
            existingCustomer.DateOfBirth = updatedCustomer.DateOfBirth;
            existingCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
            existingCustomer.Email = updatedCustomer.Email;
            existingCustomer.BankAccountNumber = updatedCustomer.BankAccountNumber;

            existingCustomer.UpdateTime = DateTime.UtcNow;

            _context.Customers.Update(existingCustomer);

            await _context.SaveChangesAsync();

            return existingCustomer;
        }

        public async Task<bool> DeleteCustomerAsync(Guid id)
        {
            var customerToRemove = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id && !c.IsRemoved);
            if (customerToRemove is null)
                return false;

            customerToRemove.IsRemoved = true;
            customerToRemove.RemoveTime = DateTime.UtcNow;

            _context.Customers.Update(customerToRemove);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IsFirstNameLastNameDateOfBirthUnique(CustomerCreateUpdateDto customer, Guid? id)
        {
            var result = false;

            var query = _context.Customers.Where(c =>
                            c.FirstName == customer.FirstName &&
                            c.LastName == customer.LastName &&
                            c.DateOfBirth.Date == customer.DateOfBirth.Date);

            if (id is not null)
                query = query.Where(c => c.Id != id);

            var customerExists = await query.FirstOrDefaultAsync();

            if (customerExists is null)
                result = true;

            return result;
        }

        public async Task<bool> IsEmailUnique(CustomerCreateUpdateDto customer, Guid? id)
        {
            var query = _context.Customers.Where(c => c.Email == customer.Email);

            if (id is not null)
                query = query.Where(c => c.Id != id);

            var customerExists = await query.FirstOrDefaultAsync();

            return customerExists == null;
        }
    }
}