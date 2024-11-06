using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class DbCustomerRepository : ICustomerRepository
{
    public Task<Customer> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Customer>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Customer>> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task Add(Customer entity)
    {
        throw new NotImplementedException();
    }
}