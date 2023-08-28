namespace Human.Details.api.Repository;

public interface IShopRepository<T>
{
    Task AddAsync(T entity);
}