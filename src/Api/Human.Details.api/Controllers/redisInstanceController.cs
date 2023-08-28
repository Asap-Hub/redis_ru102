using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
namespace Human.Details.api;
using StackExchange.Redis;

[ApiController]
[Route("[controller]/[action]")]

public class redisInstanceController: ControllerBase
{
    private readonly IConnectionMultiplexer _redisConnection;
    

    public redisInstanceController(IConnectionMultiplexer ConnectionMultiplexer)
    {
        _redisConnection= ConnectionMultiplexer;
    }
    
    [HttpPost]
    public async Task SaveData()
    {
        var date = DateTime.Now;
        var key = "Flash:chat:23425235";
        var totalCount = 20;
        
        
        Console.WriteLine("it took {0} to complete this initiation", date);
        IDatabase redisDb = _redisConnection.GetDatabase();
        
        var sendData = new UserInfo()
        {
            id = Guid.NewGuid().ToString("N"),
            value = "Ama",
            age = "20"
            
        };
        
        var data = JsonSerializer.Serialize(sendData);
       
        var setData = new RedisValue[]
        {
            "rer", "fefe" 
        };

      
        var list = redisDb.ListLeftPush(key: key,  value:data);
        var String = redisDb.StringSet(key: key, value: data);
        var set = redisDb.SetAdd(key: key, setData);
        TimeSpan tm = redisDb.Ping(); 
        Console.WriteLine("it took {0} to complete this initiation, {1} with key", tm,  key);
    }

    
    [HttpGet]
    public async Task<response> GetData(string key)
    {
        var valueKey = Guid.NewGuid().ToString("N");
        Console.WriteLine("it took {0} to complete this initiation");
        
        IDatabase redisDb = _redisConnection.GetDatabase();
        var saveData = redisDb.ListRightPop(key: key);
       var result =  JsonSerializer.Deserialize<UserInfo>(saveData).ToString();
       
        Console.WriteLine("key {0} : value {1}",key, saveData);
        return new response()
        {
            key = key,
            data = saveData.ToString().Normalize()
        };
    }

    [HttpPost]
    public async Task AddStream()
    {
        //initailize db
        IDatabase db = _redisConnection.GetDatabase();
        
        //redis key
        var sensor1 = "sensor:1";
        var sensor2 = "sensor:2";
        //random number generator
        var rnd = new Random();
        long numInserted = 0;
        var s1Temp = 28;
        var s2Temp = 5;
        var s1Humid = 35;
        var s2Humid = 87;
        
        while (true)
        {
            await db.StreamAddAsync(sensor1, new[]
            {
                new NameValueEntry("temp", s1Temp),
                new NameValueEntry("humidity", s1Humid)
            });

            await db.StreamAddAsync(sensor2, new[]
            {
                new NameValueEntry("temp", s2Temp),
                new NameValueEntry("humidity", s2Humid)
            });

            await Task.Delay(1000);

            numInserted++;
            if (numInserted % 5 == 0)
            {
                s1Temp = s1Temp + rnd.Next(3) - 2;
                s2Temp = s2Temp + rnd.Next(3) - 2;
                s1Humid = Math.Min(s1Humid + rnd.Next(3) - 2, 100);
                s2Humid = Math.Min(s2Humid + rnd.Next(3) - 2, 100);
            }
        }
    }
    
}