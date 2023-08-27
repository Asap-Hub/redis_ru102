namespace Human.Details.api.Extension;
using StackExchange.Redis; 

public static class RedisServiceConfiguration
{
    public static IServiceCollection RedisServiceExtension(this IServiceCollection service)
    {
        var option = new ConfigurationOptions()
        {
            EndPoints = {"127.0.0.1:6379"}
        };
        
        service.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(option));    
         
        return service;
    }
}