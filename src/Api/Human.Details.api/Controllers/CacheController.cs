using System.Diagnostics;
using System.Timers;
using Human.Details.api.DTOs;
using Human.Details.api.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Timer = System.Threading.Timer;


namespace Human.Details.api;

[ApiController]
[Route("api/[Controller]/[action]")]
public class CacheController : ControllerBase
{
    private readonly ISaleService _saleService;
    private readonly IEmployeeService _employeeService;
    private readonly IDistributedCache _distributedCache;

    public CacheController(ISaleService saleService, IEmployeeService employeeService,
        IDistributedCache distributedCache)
    {
        _saleService = saleService;
        _employeeService = employeeService;
        _distributedCache = distributedCache;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSales([FromBody] CreateSaleDto sale)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        var data = sale.Adapt<Sale>();
        var res = await _saleService.AddSaleAsync(data);
        if (res != null)
        {
            return StatusCode(StatusCodes.Status201Created);
        }

        return StatusCode(StatusCodes.Status400BadRequest);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto employeeDto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        var request = employeeDto.Adapt<Employee>();
        var res = await _employeeService.AddEmployee(request);
        if (res.EmployeeId != null)
        {
            return StatusCode(StatusCodes.Status201Created);
        }

        return StatusCode(StatusCodes.Status400BadRequest);
    }

    [HttpGet]
    public async Task<List<Employee>> TopSalesperson()
    {
        var topSalesperson = _employeeService.GetAll().Result.ToList().FirstOrDefault();
         
   
var cacheOptions = new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) };
        var topSalesInsertTask =   _distributedCache.SetStringAsync("top:sales", topSalesperson.ToString(), cacheOptions);
        var topNameInsertTask =   _distributedCache.SetStringAsync("top:name", topSalesperson.Name, cacheOptions);
        await Task.WhenAll(topSalesInsertTask, topNameInsertTask);
        
        var topSalesTask = _distributedCache.GetStringAsync("top:sales");
        var topNameTask = _distributedCache.GetStringAsync("top:name");
        
        await Task.WhenAll(topSalesTask, topNameTask);
        var time  =  Stopwatch.StartNew();
        if (!string.IsNullOrEmpty(topSalesTask.Result) && !string.IsNullOrEmpty(topNameTask.Result))
        {
            Console.WriteLine("sum_sales: {0}, || employee_name: {1} || time: {2}",topSalesTask, topNameTask, time.ElapsedMilliseconds);
            return new List<Employee>();

        }

        return null;
    }
}