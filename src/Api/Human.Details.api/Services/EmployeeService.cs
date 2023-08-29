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
        await _employeeService.AddAsync(employee);
       return new Employee();
    }
}