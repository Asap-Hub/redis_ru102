using Human.Details.api.DTOs;
using Human.Details.api.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;
 

namespace Human.Details.api;

[ApiController]
[Route("api/[Controller]/[action]")]
public class CacheController : ControllerBase
{
    private readonly ISaleService _saleService;
    private readonly IEmployeeService _employeeService;

    public CacheController(ISaleService saleService, IEmployeeService employeeService)
    {
        _saleService = saleService;
        _employeeService = employeeService;
    }

    [HttpPost]
    public async  Task<IActionResult> CreateSales([FromBody] CreateSaleDto sale)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        } 
        var data =   sale.Adapt<Sale>();
     var res =   await _saleService.AddSaleAsync(data);
     if (res != null)
     {
         return StatusCode(StatusCodes.Status201Created);
     }
     return StatusCode(StatusCodes.Status400BadRequest);
    }
    
    [HttpPost]
    public async  Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto employeeDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        } 
        var request =   employeeDto.Adapt<Employee>();
     var res =   await _employeeService.AddEmployee(request);
     if (res.EmployeeId != null)
     {
         return StatusCode(StatusCodes.Status201Created);
     }
     return StatusCode(StatusCodes.Status400BadRequest);
    }
    
    
}