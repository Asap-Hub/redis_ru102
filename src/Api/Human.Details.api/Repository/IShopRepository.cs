using Microsoft.EntityFrameworkCore;

namespace Human.Details.api.Repository;

public interface IShopRepository<T> where T : class
{
    Task<T> AddAsync(T entity);

     IEnumerable<T> GetAll();
   // Task GetTopSalespersonAsync();
    
    
}