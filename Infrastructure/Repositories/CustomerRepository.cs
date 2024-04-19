using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CrudDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<Customer?> CreateAsync(Customer input)
        {
            try
            {
                await _Entities.AddAsync(input);
                await _DbContext.SaveChangesAsync();
                return input;
            }
            catch (Exception ex) { return null; }
        }

        public async Task DeleteAsync(Customer input)
        {
            _Entities.Remove(input);
            await _DbContext.SaveChangesAsync();
        }

        public async Task<Customer?> GetAsync(int id)
        {
            return await _Entities.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Customer?> GetAsync(string firstName, string lastName, DateTime birthDay)
        {
            return await this._Entities.FirstOrDefaultAsync(x => x.FirstName == firstName && x.LastName == lastName && x.DateOfBirth == birthDay);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _Entities.ToListAsync();
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            return await this._Entities.SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Customer?> UpdateAsync(Customer input)
        {
            try
            {
                _Entities.Update(input);
                await _DbContext.SaveChangesAsync();
                return input;
            }
            catch (Exception ex) { return null; }
        }
    }
}
