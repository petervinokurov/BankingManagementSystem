using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankingManagementSystem.Domains.UserManagementDomain.Commands;
using BankingManagementSystem.Domains.UserManagementDomain.Responses;
using BankingManagementSystem.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BankingManagementSystem.Domains.UserManagementDomain.Handlers;

public class DeleteRolesCommandHandler : IRequestHandler<DeleteRolesCommand, DeleteRolesResponse>
{
    private readonly BankingManagementSystemContext _context;

    public DeleteRolesCommandHandler(BankingManagementSystemContext context)
    {
        _context = context;
    }

    public async Task<DeleteRolesResponse> Handle(DeleteRolesCommand request, CancellationToken cancellationToken)
    {
        var response = new DeleteRolesResponse();
        var rolesToRemove = await _context.Roles.Where(r => request.RoleIds.Contains(r.Id))
            .ToListAsync(cancellationToken: cancellationToken);
        //TODO Add input validation.
        _context.Roles.RemoveRange(rolesToRemove);
        await _context.SaveChangesAsync(cancellationToken);
        response.DeletedRoleIds = rolesToRemove.Select(r => r.Id).ToList();
        return await Task.FromResult(response);
    }
}