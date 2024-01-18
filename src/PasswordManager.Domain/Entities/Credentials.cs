namespace PasswordManager.Domain.Entities;

public class Credential(string? credentialName, string username, string emailAdress, string webSite, string passwordHash)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string WebSite { get; private set; } = webSite;
    public string CredentialName { get; private set; } = credentialName ?? new Uri(webSite).HostNameType.ToString();
    public string Username { get; private set; } = username;
    public string EmailAddress { get; private set; } = emailAdress;
    public string PasswordHash { get; private set; } = passwordHash;

    private void UpdateCredential(string? website, string? credentialName, string? username, string? emailAddress, string? passwordHash)
    {
        WebSite = website ?? WebSite;
        CredentialName = credentialName ?? CredentialName;
        Username = username ?? Username;
        EmailAddress = emailAddress ?? EmailAddress;
        PasswordHash = passwordHash ?? PasswordHash;
    }

    private static string GeneratePassword(uint lenght = 12, bool upperCase = true, bool lowercase = true, bool numbers = true, bool specialCharacters = true)
    {
        var password = new System.Text.StringBuilder();
        var random = new Random();
        var characters = new List<char>();

        if (upperCase)
            characters.AddRange(Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => (char)i));

        if (lowercase)
            characters.AddRange(Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (char)i));

        if (numbers)
            characters.AddRange(Enumerable.Range('0', '9' - '0' + 1).Select(i => (char)i));

        if (specialCharacters)
            characters.AddRange(Enumerable.Range('!', '/').Select(i => (char)i));

        for (var i = 0; i < lenght; i++)
        {
            var index = random.Next(0, characters.Count);
            password.Append(characters[index]);
        }

        return password.ToString();
    }
}