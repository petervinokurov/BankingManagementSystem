using System.Collections.Generic;

namespace BankingManagementSystem.Domains.UserManagementDomain;

public class UpdateUsersRequest
{
    public IEnumerable<UserDto> Users { get; set; }
}