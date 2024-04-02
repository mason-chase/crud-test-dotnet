using Application.Common.Interfaces.Repositories;
using Application.DTOs.Customer.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly CrudTestDbContext _dbContext;

        public CustomerRepository(CrudTestDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<bool> IsCustomerUnique(string firstName, string lastName, DateTime dayOfBirth)
        {
            return !await _dbContext.Customers.AsNoTracking().AnyAsync
                (i => i.FirstName == firstName && i.LastName == lastName && i.DateOfBirth == dayOfBirth);
        }

        public async Task<bool> IsEmailUnique(string email)
        {
            return !await _dbContext.Customers.AsNoTracking().AnyAsync
                 (i => i.Email == email);
        }

        public async Task<bool> IsCustomerUnique(int id,string firstName, string lastName, DateTime dayOfBirth)
        {
            return !await _dbContext.Customers.AsNoTracking().AnyAsync
                (i =>i.Id!=id && i.FirstName == firstName && i.LastName == lastName && i.DateOfBirth == dayOfBirth);
        }

        public async Task<bool> IsEmailUnique(int id,string email)
        {
            return !await _dbContext.Customers.AsNoTracking().AnyAsync
                 (i =>i.Id!=id && i.Email == email);
        }

        public async Task<List<Customer>> Search(CustomerSearchDto customerSearchDto)
        {
            return await _dbContext.Customers.AsNoTracking().Where
                 (i => (string.IsNullOrEmpty(customerSearchDto.Name) || i.FirstName.Contains(customerSearchDto.Name.TrimEnd()) || i.LastName.Contains(customerSearchDto.Name.TrimEnd()))
                  && (string.IsNullOrEmpty(customerSearchDto.Email) || i.Email.Contains(customerSearchDto.Email.TrimEnd())) 
                  && (customerSearchDto.PhoneNumber==0 || i.PhoneNumber==customerSearchDto.PhoneNumber)
                  && (customerSearchDto.DateOfBirth == null || i.DateOfBirth == customerSearchDto.DateOfBirth)).ToListAsync();
        }
    }
}
