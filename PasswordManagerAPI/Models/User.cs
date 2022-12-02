namespace PasswordManagerAPI.Models;

public class User
{
    public int Type { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public IList<Credential> Credentials { get; set; }
}