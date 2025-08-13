using System;
using System.Threading.Tasks;

namespace BankingManagementSystem.Services;

public interface IDistributedCacheService
{
    Task<T> GetAsync<T>(string key);
    Task SetAsync<T>(string key, T value, TimeSpan? expiration = null);
    Task RemoveAsync(string key);
}