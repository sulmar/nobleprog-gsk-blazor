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

    public T Get(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T> GetAll()
    {
        return _entities.AsQueryable();
    }
}
