using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeEntityRepository<T> : IEntityRepository<T>
    where T : BaseEntity
{
    protected readonly IEnumerable<T> _entities;

    public FakeEntityRepository(IEnumerable<T> entities)
    {
        _entities = entities;
    }

    public Task<T> GetAsync(int id)
    {
        return Task.FromResult(_entities.SingleOrDefault(p=>p.Id == id));
    }

    public Task<IQueryable<T>> GetAllAsync()
    {
        return Task.FromResult(_entities.AsQueryable());
    }
}
