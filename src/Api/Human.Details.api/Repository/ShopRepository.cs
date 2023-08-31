using Human.Details.api.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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

    public IEnumerable<T> GetAll()
    {
        return _dbContext.Set<T>();
    }

    // public   Task<T> GetAll()
    // {
    //     return _dbContext.Set<T>();
    // }

   
    
    // public async Task GetTopSalespersonAsync()
    // {
    //     await _dbContext.Employees.Select(x => new { Entity = x, SumSales = (x as Employee).Sales.Sum(s => s.Total) })
    //      .OrderByDescending(x => x.SumSales).Select(x => x.Entity)
    //     .FirstOrDefaultAsync(); 
    // }
}