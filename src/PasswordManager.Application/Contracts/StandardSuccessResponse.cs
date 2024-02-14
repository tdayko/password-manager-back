namespace PasswordManager.Application.Contracts;

public record StandardSuccessResponse
{
    public bool Success { get; init; } = true;
    public required object Data { get; init; } 
}