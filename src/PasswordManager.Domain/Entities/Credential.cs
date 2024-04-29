namespace PasswordManager.Domain.Entities;

public class Credential(string username, string email, string password, Uri webSite)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Uri WebSite { get; private set; } = webSite;
    public string Username { get; private set; } = username;
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
    public User User { get; private set; } 

    public void UpdateCredential(Uri? website, string? username, string? email, string? password)
    {
        WebSite = website ?? WebSite;
        Username = username ?? Username;
        Email = email ?? Email;
        Password = password ?? Password;
    }

    public void AddUserToCredential(User user) => User = user;

    public static string GeneratePassword(uint length = 12, bool useUpperCase = true, bool useLowerCase = true, 
        bool useNumbers = true, bool useSpecialCharacters = true)
    {
        Random random = new();
        string[] characterSets =
        [
            useUpperCase ? "ABCDEFGHIJKLMNOPQRSTUVWXYZ" : string.Empty,
            useLowerCase ? "abcdefghijklmnopqrstuvwxyz" : string.Empty,
            useNumbers ? "0123456789" : string.Empty,
            useSpecialCharacters ? "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~" : string.Empty
        ];

        var allCharacters = characterSets
            .Where(x => !string.IsNullOrEmpty(x))
            .Aggregate(string.Empty, (acc, x) => acc + x);

        var password = new string(Enumerable
            .Range(0, (int)length)
            .Select(x => allCharacters[random.Next(allCharacters.Length)])
            .ToArray()
        );

        return password;
    }
}