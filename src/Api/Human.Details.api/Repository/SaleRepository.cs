using Human.Details.api.Data;
using Microsoft.EntityFrameworkCore;

namespace Human.Details.api.Repository;

public class SaleRepository :IShopRepository<Sale>
{
    private readonly ApplicationDbContext _dbContext;

    public SaleRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddAsync(Sale sale)
    {
        await _dbContext.AddAsync(sale);
        await _dbContext.SaveChangesAsync();
    }
}