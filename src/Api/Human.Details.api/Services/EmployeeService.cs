using Human.Details.api.Repository;

namespace Human.Details.api.Services;

public class EmployeeService:IEmployeeService
{
    private readonly IShopRepository<Employee> _employeeService;

    public EmployeeService(IShopRepository<Employee> employeeService)
    {
        _employeeService = employeeService;
    }
    public async Task<Employee> AddEmployee(Employee employee)
    {
        //redis
        //  
        // var cacheOptions = new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) };
        // var topSalesInsertTask = _cache.SetStringAsync("top:sales", topSalesperson.sumSales.ToString(), cacheOptions);
        await _employeeService.AddAsync(employee);
       return new Employee();
    }

    public async Task<List<Employee>> GetAll()
    {
     //  return _employeeService.GetAll().Where(x => x.EmployeeId == x.Sales.Where(y => y.EmployeeId).AsQueryable().FirstOrDefault();
    // return _employeeService.GetAll().Where(x => x.EmployeeId >= 0 && x.Sales.Any(sale => sale.SaleId == x.EmployeeId)).ToList(); 
    return   _employeeService.GetAll().Where(x => x.EmployeeId > 0 && x.Name.Length > 0).AsQueryable().ToList();
      
    }
 
}