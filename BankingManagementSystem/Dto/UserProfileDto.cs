using System;

namespace BankingManagementSystem.Dto;

public class UserProfileDto
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public byte[] ProfilePicture { get; set; }
}