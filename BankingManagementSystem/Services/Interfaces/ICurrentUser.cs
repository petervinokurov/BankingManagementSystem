using System.Collections.Generic;

namespace BankingManagementSystem.Services;

public interface ICurrentUser
{
    string UserId { get; }
    
    string Email { get; }
    bool IsAuthenticated { get; }
    
    IEnumerable<string> Roles { get; }
}