using System.Collections.Generic;

namespace BankingManagementSystem.Dto;

public class ApplicationDataChange
{
    public string PropertyName { get; set; }
    public List<string> Values { get; set; }
}