namespace PasswordManager.Application.Contracts;

public class StandardSuccessResponse<T>(T data) where T : UserResponse
{
    public bool Success { get; init; } = true;
    public T Data { get; init; } = data;
}