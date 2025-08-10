using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace BankingManagementSystem.Services;

public class DistributedCacheService : IDistributedCacheService
{
    private readonly IDistributedCache _cache;

    public DistributedCacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<T> GetAsync<T>(string key)
    {
        var data = await _cache.GetStringAsync(key);
        if (string.IsNullOrEmpty(data)) return default;

        return JsonSerializer.Deserialize<T>(data);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
    {
        var options = new DistributedCacheEntryOptions();
        if (expiration.HasValue)
            options.SetAbsoluteExpiration(expiration.Value);

        var json = JsonSerializer.Serialize(value);
        await _cache.SetStringAsync(key, json, options);
    }

    public Task RemoveAsync(string key)
    {
        return _cache.RemoveAsync(key);
    }
}