using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BankingManagementSystem.Domains.UserManagementDomain.Commands;
using BankingManagementSystem.Domains.UserManagementDomain.Responses;
using BankingManagementSystem.Dto;
using BankingManagementSystem.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BankingManagementSystem.Domains.UserManagementDomain.Handlers;

public class UpdateRolesCommandHandler : IRequestHandler<UpdateRolesCommand, UpdateRolesResponse>
{
    private readonly BankingManagementSystemContext _context;
    private readonly IMapper _mapper;

    public UpdateRolesCommandHandler(BankingManagementSystemContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UpdateRolesResponse> Handle(UpdateRolesCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateRolesResponse();
        var repositoryRoles = await _context.Roles.Include(r => r.RoleClaims)
            .Where(r => request.UpdateRoles.Select(x => x.Id).Contains(r.Id)).ToListAsync(cancellationToken: cancellationToken);

        repositoryRoles.ForEach(rr =>
        {
            var role = request.UpdateRoles.Single(r => r.Id == rr.Id);
            _mapper.Map(role, rr);
        });
        await _context.SaveChangesAsync(cancellationToken);
        response.UpdatedRoles = _mapper.Map<IEnumerable<RoleDto>>(repositoryRoles);
        return await Task.FromResult(response);
    }
}