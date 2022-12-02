namespace PasswordManagerAPI.Models;

public class Credential
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Uri { get; set; } 
}