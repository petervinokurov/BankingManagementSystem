namespace BankingManagementSystem;

public class CsrfSettings
{
    public string XsrfToken { get; set; } = "XSRF-TOKEN";

    public string CsrfHeader { get; set; } = "X-Xsrf-Token";
}