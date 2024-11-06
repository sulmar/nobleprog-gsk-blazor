using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeCustomerRepository : FakeEntityRepository<Customer>, ICustomerRepository
{
    public FakeCustomerRepository(IEnumerable<Customer> entities) : base(entities)
    {
    }

    public Task<IQueryable<Customer>> GetByNameAsync(string name)
    {
        return Task.FromResult(_entities.Values.Where(e => e.Name.Contains(name)).AsQueryable());
    }
}
