using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeUserResopitory : FakeEntityRepository<User>, IUserRepository
{
    public FakeUserResopitory(IEnumerable<User> entities) : base(entities)
    {
    }

    public User GetByEmail(string email)
    {
        return _entities.SingleOrDefault(e => e.Email == email);
    }
}
