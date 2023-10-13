using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BankingManagementSystem.Domains.UserManagementDomain.Commands;
using BankingManagementSystem.Domains.UserManagementDomain.Responses;
using BankingManagementSystem.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BankingManagementSystem.Domains.UserManagementDomain.Handlers;

public class CreateUsersCommandHandler : IRequestHandler<CreateUsersCommand, CreateUsersResponse>
{
    private readonly BankingManagementSystemContext _context;
    private readonly IMapper _mapper;

    public CreateUsersCommandHandler(BankingManagementSystemContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateUsersResponse> Handle(CreateUsersCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateUsersResponse();
        var existedUsers = await _context.Users
            .Where(r => request.NewUsers.Select(x => x.Email.ToUpperInvariant()).Contains(r.Email)).Select(x => x.Email)
            .ToListAsync(cancellationToken: cancellationToken);
        response.ApplicationError = string.Join(',',
            existedUsers.Select(x => $"User {x} already exist.{Environment.NewLine}").ToArray());
        var newUsers = request.NewUsers.Where(r => !existedUsers.Contains(r.Email)).Select(u =>
        {
            var user = _mapper.Map<User>(u);
            user.Roles = _context.Roles.Where(r => u.Roles.Select(ur => ur.Id).Contains(r.Id)).ToList();
            return user;
        });
        await _context.Users.AddRangeAsync(newUsers, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
        return await Task.FromResult(response);
    }
}