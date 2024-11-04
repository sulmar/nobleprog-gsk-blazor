using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class DbCustomerRepository : ICustomerRepository
{
    public Customer Get(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Customer> GetAll()
    {
        throw new NotImplementedException();
    }
}