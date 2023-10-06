using System.Collections.Generic;

namespace BankingManagementSystem.Domains.UserManagementDomain;

public class CreateUsersRequest
{
    public IEnumerable<UserDto> NewUsers { get; set; }
}