using Domain.Models;

namespace Domain.Abstractions;

public interface IEntityRepository<T>
    where T : BaseEntity
{
    Task<IQueryable<T>> GetAllAsync();
    Task<T> GetAsync(int id);
}
