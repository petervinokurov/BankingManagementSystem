using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BankingManagementSystem.Domains.UserProfileDomain.Commands;
using BankingManagementSystem.Domains.UserProfileDomain.Responses;
using BankingManagementSystem.Entities;
using MediatR;

namespace BankingManagementSystem.Domains.UserProfileDomain.Handlers;

public class UpdateProfilePhotoHandler : IRequestHandler<UpdateProfilePhotoCommand, UpdateProfilePhotoResponse>
{
    private readonly BankingManagementSystemContext _context;
    private readonly IMapper _mapper;
    
    public UpdateProfilePhotoHandler(BankingManagementSystemContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<UpdateProfilePhotoResponse> Handle(UpdateProfilePhotoCommand request, CancellationToken token)
    {
        var user = await _context.Users.FindAsync(new object[] { request.UserId }, cancellationToken: token) ?? throw new KeyNotFoundException();
        user.ProfilePhoto = request.Photo;
        await _context.SaveChangesAsync(cancellationToken: token);
        return new UpdateProfilePhotoResponse();
    }
}