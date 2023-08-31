using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
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


    public static IServiceCollection RedisDistributedCacheService(this IServiceCollection service)
    {
       service.AddStackExchangeRedisCache(x => x.ConfigurationOptions = new ConfigurationOptions
        {
            EndPoints = {"127.0.0.1:6379"},
        });
       return service;
    }
}