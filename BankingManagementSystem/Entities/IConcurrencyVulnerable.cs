namespace BankingManagementSystem.Entities;

public interface IConcurrencyVulnerable
{
     public static string ConcurrencyCheckField => nameof(ConcurrencyStamp);
     string ConcurrencyStamp { get; set; }
}