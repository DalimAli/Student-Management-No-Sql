using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace Student_Management_No_Sql.Cache;

public class CacheService : ICacheService
{
    private readonly IDistributedCache _distributedCache;

    public CacheService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task<T> GetCachedDataAsync<T>(string key)
    {
        var jsonData = await _distributedCache.GetStringAsync(key);
        if (jsonData == null)
            return default(T);
        return JsonSerializer.Deserialize<T>(jsonData);
    }

    public async Task SetCachedDataAsync<T>(string key, T data, TimeSpan cacheDuration)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = cacheDuration,
        };

        var jsonData = JsonSerializer.Serialize(data);
        await _distributedCache.SetStringAsync(key, jsonData, options);
    }

    public async Task RemoveAsync(string key)
    {
        await _distributedCache.RemoveAsync(key);
    }
    
    // public async Task RemoveAllAsync(string like)
    // {
    //     await _distributedCache.Re(like);
    // }
}