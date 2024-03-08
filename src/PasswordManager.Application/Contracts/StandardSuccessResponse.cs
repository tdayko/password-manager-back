namespace PasswordManager.Application.Contracts;

public class StandardSuccessResponse<T>(T data)
{
    public bool Success { get; init; } = true;
    public T Data { get; init; } = data;
}
