using Domain.Models;

namespace Domain.Abstractions;

public interface IEntityRepository<T>
    where T : BaseEntity
{
    IQueryable<T> GetAll();
    T Get(int id);
}
