using System;
using System.Linq.Expressions;
using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Repositories;

public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
{
    private readonly IGenericRepository<Customer> _genericRepository;
    private IDbContextTransaction _transaction;
    private readonly ApplicationDbContext _context; // Assuming ApplicationDbContext is your DbContext

    public CustomerRepository(ApplicationDbContext context, IGenericRepository<Customer> genericRepository)
        : base(context)
    {
        _context = context;
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
    {
        try
        {
            return await _genericRepository.Update(customer);
        }
        catch (Exception)
        {
            return false;
        }
    }

   
    public async Task<bool> DeleteAsync(int id)
    => await _genericRepository.Delete(id);

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
        return _transaction;
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
        }
    }
}