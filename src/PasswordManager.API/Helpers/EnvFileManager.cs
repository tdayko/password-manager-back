namespace PasswordManager.API.Helpers;

static public class EnvFileManager
{    
    public static string GetEnvFilePath(string startingDirectory, string envFileName = ".env")
    {
        DirectoryInfo? dir = new(startingDirectory);

        while (dir != null && dir.Exists)
        {
            string envFilePath = Path.Combine(dir.FullName, envFileName);
            if (File.Exists(envFilePath))
            {
                return envFilePath;
            }
            dir = dir.Parent;
        }

        throw new FileNotFoundException(".env file not found");
    }
}