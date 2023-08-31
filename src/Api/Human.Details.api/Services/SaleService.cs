using Human.Details.api.Repository;
using Microsoft.Extensions.Caching.Distributed;

namespace Human.Details.api.Services;

public class SaleService : ISaleService
{
    private readonly IShopRepository<Sale> _saleService;
    private readonly IDistributedCache _cache;
    public SaleService(IShopRepository<Sale> saleService, IDistributedCache cache)
    {
        _saleService = saleService;
        _cache = cache;
    }
 
    public async Task<Sale> AddSaleAsync(Sale sale)
    {
        //redis
      var rest = await _saleService.AddAsync(sale);
      return sale;
    }
}