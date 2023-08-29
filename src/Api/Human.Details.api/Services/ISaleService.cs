namespace Human.Details.api.Services;

public interface ISaleService
{
    Task<Sale> AddSaleAsync(Sale sale);
}