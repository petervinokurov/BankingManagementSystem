using System;
using BankingManagementSystem.Domains.UserProfileDomain.Responses;
using MediatR;

namespace BankingManagementSystem.Domains.UserProfileDomain.Commands;

public class UpdateProfilePhotoCommand : IRequest<UpdateProfilePhotoResponse>
{
    public Guid UserId { get; set; }

    public string Photo { get; set; }
}