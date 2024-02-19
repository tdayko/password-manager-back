namespace PasswordManager.Domain.Entities;

public class Credential(
    string? credentialName,
    string username,
    string emailAdress,
    string webSite,
    string passwordHash)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string WebSite { get; private set; } = webSite;
    public string CredentialName { get; private set; } = credentialName ?? new Uri(webSite).HostNameType.ToString();
    public string Username { get; private set; } = username;
    public string EmailAddress { get; private set; } = emailAdress;
    public string PasswordHash { get; private set; } = passwordHash;

    private void UpdateCredential(string? website, string? credentialName, string? username, string? emailAddress,
        string? passwordHash)
    {
        WebSite = website ?? WebSite;
        CredentialName = credentialName ?? CredentialName;
        Username = username ?? Username;
        EmailAddress = emailAddress ?? EmailAddress;
        PasswordHash = passwordHash ?? PasswordHash;
    }

    private static string GeneratePassword(uint length = 12, bool useUpperCase = true, bool useLowerCase = true,
        bool useNumbers = true, bool useSpecialCharacters = true)
    {
        string password = string.Empty;
        Random random = new Random();

        string[] characterSets = new[]
        {
            useUpperCase ? "ABCDEFGHIJKLMNOPQRSTUVWXYZ" : string.Empty,
            useLowerCase ? "abcdefghijklmnopqrstuvwxyz" : string.Empty, useNumbers ? "0123456789" : string.Empty,
            useSpecialCharacters ? "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~" : string.Empty
        };

        string allCharacters = characterSets.Where(x => !string.IsNullOrEmpty(x))
            .Aggregate(string.Empty, (acc, x) => acc + x);
        password = new string(Enumerable.Range(0, (int)length)
            .Select(x => allCharacters[random.Next(allCharacters.Length)]).ToArray());

        return password;
    }
}