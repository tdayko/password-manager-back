namespace PasswordManager.IoC.Authentication;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";

    public string? SecrectKey { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public int ExpiryMinutes { get; set; }
}
