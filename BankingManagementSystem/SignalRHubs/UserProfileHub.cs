using System;
using System.Threading.Tasks;
using BankingManagementSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace BankingManagementSystem.SignalRHubs;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UserProfileHub : Hub
{
    private readonly IDistributedCacheService _distributedCacheService;

    public UserProfileHub(IDistributedCacheService distributedCache)
    {
        _distributedCacheService = distributedCache;
    }
    
    public override async Task OnConnectedAsync()
    {
        var userId = Context.User?.Identity?.Name;

        if (!string.IsNullOrEmpty(userId))
        {
            var connectionId = Context.ConnectionId;
            await _distributedCacheService.SetAsync(userId, connectionId);
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        var userId = Context.User?.Identity?.Name;

        if (!string.IsNullOrEmpty(userId))
        {
            await _distributedCacheService.RemoveAsync(userId);
        }

        await base.OnDisconnectedAsync(exception);
    }
}