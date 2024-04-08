namespace PasswordManager.Domain.Entities;

public class Credential(
    User user,
    string username,
    string email,
    string password,
    string webSite
)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string WebSite { get; private set; } = webSite;
    public string Username { get; private set; } = username;
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
    public User User { get; init; } = user;

    private void UpdateCredential(
        string? website,
        string? username,
        string? email,
        string? password
    )
    {
        WebSite = website ?? WebSite;
        Username = username ?? Username;
        Email = email ?? Email;
        Password = password ?? Password;
    }

    private static string GeneratePassword(
        uint length = 12,
        bool useUpperCase = true,
        bool useLowerCase = true,
        bool useNumbers = true,
        bool useSpecialCharacters = true
    )
    {
        var password = string.Empty;
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

        password = new string(Enumerable
            .Range(0, (int)length)
            .Select(x => allCharacters[random.Next(allCharacters.Length)])
            .ToArray()
        );

        return password;
    }
}