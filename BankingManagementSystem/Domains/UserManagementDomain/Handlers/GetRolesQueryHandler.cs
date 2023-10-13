using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankingManagementSystem.Domains.UserManagementDomain.Queries;
using BankingManagementSystem.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BankingManagementSystem.Domains.UserManagementDomain.Handlers;

public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<BmsRoleProjection>>
{
    private readonly BankingManagementSystemContext _context;
    private readonly IMapper _mapper;

    public GetRolesQueryHandler(BankingManagementSystemContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public Task<List<BmsRoleProjection>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        return _context.Roles.Include(x => x.RoleClaims).ProjectTo<BmsRoleProjection>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken: cancellationToken);
    }
}