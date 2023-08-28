using Human.Details.api.Data;
using Human.Details.api.Extension;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

{
    
    
      //  var builder = WebApplication.CreateBuilder(args);         
        var service = builder.Services;
        var config = builder.Configuration;
        
    // Add services to the container.

    service.AddControllers();
    service.RedisServiceExtension();
        
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