using Human.Details.api.Data;

namespace Human.Details.api.Repository;

public class ShopRepository<T>:IShopRepository<T> where T : class
{
    private readonly ApplicationDbContext _dbContext;

    public ShopRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity); 
        await _dbContext.SaveChangesAsync();
        return null;
    }
}