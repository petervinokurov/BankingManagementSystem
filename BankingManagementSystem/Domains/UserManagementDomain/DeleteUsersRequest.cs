using System;
using System.Collections.Generic;

namespace BankingManagementSystem.Domains.UserManagementDomain;

public class DeleteUsersRequest
{
    public IEnumerable<Guid> UserIds { get; set; } = new List<Guid>();
}