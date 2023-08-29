using Human.Details.api.Repository;

namespace Human.Details.api.Services;

public class SaleService : ISaleService
{
    private readonly IShopRepository<Sale> _saleService;

    public SaleService(IShopRepository<Sale> saleService)
    {
        _saleService = saleService;
    }
 
    public async Task<Sale> AddSaleAsync(Sale sale)
    {
      var rest = await _saleService.AddAsync(sale);
      return sale;
    }
}