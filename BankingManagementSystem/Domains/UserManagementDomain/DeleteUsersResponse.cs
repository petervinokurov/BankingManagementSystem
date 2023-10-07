using System;
using System.Collections.Generic;

namespace BankingManagementSystem.Domains.UserManagementDomain;

public class DeleteUsersResponse
{
    public IEnumerable<Guid> UserIds { get; set; } = new List<Guid>();
}