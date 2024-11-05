using Domain.Models;

namespace Domain.Abstractions;

public interface ICustomerRepository : IEntityRepository<Customer>
{
    Task<IQueryable<Customer>> GetByNameAsync(string name);
    
}
