using Human.Details.api.Data;

namespace Human.Details.api.Repository;

public class EmployeeRepository:IShopRepository<Employee>
{
    private readonly ApplicationDbContext _dbContext;

    public EmployeeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddAsync(Employee employee)
    {
        await _dbContext.AddAsync(employee);
        await _dbContext.SaveChangesAsync();
    }
}