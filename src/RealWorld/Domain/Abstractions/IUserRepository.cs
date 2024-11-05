using Domain.Models;

namespace Domain.Abstractions;

public interface IUserRepository : IEntityRepository<User>
{
    User GetByEmail(string email);
}