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

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
{
    private readonly BankingManagementSystemContext _context;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(BankingManagementSystemContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return _context.Users
            .Include(u => u.Roles)
            .Include(u => u.Claims)
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }
}