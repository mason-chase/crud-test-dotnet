using System.Linq.Expressions;
using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    private readonly IGenericRepository<Customer> _genericRepository;
    public CustomerRepository(ApplicationDbContext context, IGenericRepository<Customer> genericRepository)
        : base(context)
    {
        _genericRepository = genericRepository;
    }



    public async Task<List<Customer>> GetAllAsync()
       => await _genericRepository.All();

    public async Task<Customer> GetByIdAsync(int id)
    => await _genericRepository.GetById(id)
       ?? throw new Exception("Customer Not Found");


    public async Task<bool> AddAsync(Customer customer)
    {
        await _genericRepository.Add(customer);
        return true;
    }

    public async Task<bool> UpdateAsync(Customer customer)
      => await _genericRepository.Update(customer);


    public async Task<bool> DeleteAsync(int id)
    => await _genericRepository.Delete(id);
}