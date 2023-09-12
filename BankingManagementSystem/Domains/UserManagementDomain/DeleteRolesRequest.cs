using System;
using System.Collections.Generic;

namespace BankingManagementSystem.Domains.UserManagementDomain;

public class DeleteRolesRequest
{
    public IEnumerable<Guid> RoleIds { get; set; } = new List<Guid>();
}