using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeEntityRepository<T> : IEntityRepository<T>
    where T : BaseEntity
{
    protected readonly IDictionary<int, T> _entities;

    public FakeEntityRepository(IEnumerable<T> entities)
    {
        _entities = entities.ToDictionary(p=>p.Id);
    }

    public Task<T> GetAsync(int id)
    {
        return Task.FromResult(_entities[id]);
    }

    public Task<IQueryable<T>> GetAllAsync()
    {
        return Task.FromResult(_entities.Values.AsQueryable());
    }

    public Task Add(T entity)
    {
        int id = _entities.Values.Max(p => p.Id);

        entity.Id = ++id;
                
        _entities.Add(entity.Id, entity);

        return Task.CompletedTask;
    }
}
