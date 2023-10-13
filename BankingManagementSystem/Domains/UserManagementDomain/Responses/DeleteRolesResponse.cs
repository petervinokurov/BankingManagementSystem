using System;
using System.Collections.Generic;
using BankingManagementSystem.Dto;

namespace BankingManagementSystem.Domains.UserManagementDomain.Responses;

public class DeleteRolesResponse : BmsResponse
{
    public IEnumerable<Guid> DeletedRoleIds { get; set; } = new List<Guid>();
}