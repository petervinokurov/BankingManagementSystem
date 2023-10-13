using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankingManagementSystem.Domains.UserManagementDomain.Commands;
using BankingManagementSystem.Domains.UserManagementDomain.Responses;
using BankingManagementSystem.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BankingManagementSystem.Domains.UserManagementDomain.Handlers;

public class DeleteUsersCommandHandler : IRequestHandler<DeleteUsersCommand, DeleteUsersResponse>
{
    private readonly BankingManagementSystemContext _context;

    public DeleteUsersCommandHandler(BankingManagementSystemContext context)
    {
        _context = context;
    }

    public async Task<DeleteUsersResponse> Handle(DeleteUsersCommand request, CancellationToken cancellationToken)
    {
        var response = new DeleteUsersResponse();
        var usersToRemove = _context.Users
            .Include(u => u.Roles)
            .Include(u => u.Claims)
            .Where(r => request.UserIds.Contains(r.Id)).ToList();
        _context.Users.RemoveRange(usersToRemove);
        await _context.SaveChangesAsync(cancellationToken);
        response.UserIds = usersToRemove.Select(u => u.Id).ToList();
        return await Task.FromResult(response);
    }
}