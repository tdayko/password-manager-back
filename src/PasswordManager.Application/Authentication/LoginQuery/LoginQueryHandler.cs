using MediatR;

using PasswordManager.Application.Errors;
using PasswordManager.Application.Persistence;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Authentication.LoginQuery;

public class LoginQueryHandler(IUserRepository userRepository) : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserbyEmail(request.Email) is not User user)
        {
            throw new EmailGivenNotFoundException();
        }

        if (user.PasswordHash != request.Password)
        {
            throw new InvalidPasswordException();
        }

        return new AuthenticationResult(user, "token");
    }
}