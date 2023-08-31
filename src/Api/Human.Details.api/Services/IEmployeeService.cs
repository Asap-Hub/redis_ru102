using Human.Details.api.Repository;

namespace Human.Details.api.Services;

public interface IEmployeeService
{
    Task<Employee> AddEmployee(Employee employee);
    
    Task<List<Employee>> GetAll();
}