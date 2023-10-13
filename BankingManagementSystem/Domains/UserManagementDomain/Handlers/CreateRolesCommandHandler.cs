using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BankingManagementSystem.Domains.UserManagementDomain.Responses;
using BankingManagementSystem.Dto;
using BankingManagementSystem.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BankingManagementSystem.Domains.UserManagementDomain.Handlers;

public class CreateRolesCommandHandler : IRequestHandler<CreateRolesCommand, CreateRolesResponse>
{
    private readonly BankingManagementSystemContext _context;
    private readonly IMapper _mapper;
    
    public CreateRolesCommandHandler(BankingManagementSystemContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateRolesResponse> Handle(CreateRolesCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateRolesResponse();
        var roles = request.NewRoles.ToList();
        var existedRoles = await _context.Roles
            .Where(r => roles.Select(x => x.Name.ToUpperInvariant()).Contains(r.NormalizedName)).Select(x => x.Name)
            .ToListAsync(cancellationToken: cancellationToken);
        response.ApplicationError = string.Join(',', existedRoles.Select(x => $"Role {x} already exist.").ToArray());
        var rolesEntities = roles.Where(r => !existedRoles.Contains(r.Name)).Select(r => _mapper.Map<Role>(r)).ToList();
        await _context.Roles.AddRangeAsync(rolesEntities, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        response.CreatedRoles = _mapper.Map<IEnumerable<RoleDto>>(rolesEntities);
        return await Task.FromResult(response);
    }
}