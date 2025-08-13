using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BankingManagementSystem.Domains.UserManagementDomain.Commands;
using BankingManagementSystem.Domains.UserManagementDomain.Responses;
using BankingManagementSystem.Entities;
using BankingManagementSystem.Services;
using BankingManagementSystem.SignalRHubs;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace BankingManagementSystem.Domains.UserManagementDomain.Handlers;

public class UpdateUsersCommandHandler: IRequestHandler<UpdateUsersCommand, UpdateUsersResponse>
{
    private readonly BankingManagementSystemContext _context;
    private readonly IMapper _mapper;
    private readonly IHubContext<UserProfileHub> _userProfileHub;
    private readonly IDistributedCacheService _distributedCache;
    private readonly ICurrentUser _currentUser;

    public UpdateUsersCommandHandler(BankingManagementSystemContext context,
        IMapper mapper,
        IHubContext<UserProfileHub> userHubContext,
        IDistributedCacheService distributedCache,
        ICurrentUser currentUser)
    {
        _context = context;
        _mapper = mapper;
        _userProfileHub = userHubContext;
        _distributedCache = distributedCache;
        _currentUser = currentUser;
    }

    public async Task<UpdateUsersResponse> Handle(UpdateUsersCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateUsersResponse();
        var repositoryUsers = await _context.Users
            .Include(u => u.Roles)
            .Include(u => u.Claims)
            .Where(r => request.Users.Select(x => x.Id).Contains(r.Id)).ToListAsync(cancellationToken: cancellationToken);
        var rolesList = await _context.Roles.ToListAsync(cancellationToken: cancellationToken);

        repositoryUsers.ForEach(ur =>
        {
            var user = request.Users.Single(r => r.Id == ur.Id);
            _mapper.Map(user, ur);
            ur.Roles = rolesList.Where(rl => ur.Roles.Select(r => r.Id).Contains(rl.Id)).ToList();
        });
        await _context.SaveChangesAsync(cancellationToken);
        response.Users = request.Users;
        var connectionId = await _distributedCache.GetAsync<string>(_currentUser.Email);
        await _userProfileHub.Clients.AllExcept(connectionId).SendAsync(UserManagementHubEvents.UserUpdated, response, cancellationToken);
        return await Task.FromResult(response);
    }
}