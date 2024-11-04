using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeCustomerRepository : ICustomerRepository
{
    private readonly IEnumerable<Customer> _customers;

    public FakeCustomerRepository(IEnumerable<Customer> customers)
    {
        _customers = customers;
    }

    public Customer Get(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Customer> GetAll()
    {
        return _customers.AsQueryable();
    }
}
