using Human.Details.api;
using Human.Details.api.Data;
using Human.Details.api.DTOs;
using Human.Details.api.Extension;
using Human.Details.api.Repository;
using Human.Details.api.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;


var builder = WebApplication.CreateBuilder(args);
{      
        var service = builder.Services;
        var config = builder.Configuration;
        
    // Add services to the container.

    service.AddControllers();
    service.RedisServiceExtension();
    service.RedisDistributedCacheService();
    service.AddScoped(typeof(IShopRepository<>), typeof(ShopRepository<>));
    service.AddScoped<ISaleService,SaleService>();
    service.AddScoped<IEmployeeService, EmployeeService>(); 
    service.RegisterMapsterConfiguration(); 
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
      service.AddEndpointsApiExplorer();
      service.AddSwaggerGen();
      
       
    //adding applicationdbcontext to database
    service.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(config.GetConnectionString("DbConnection")));
    
    var app = builder.Build();

    // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();


        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    
}