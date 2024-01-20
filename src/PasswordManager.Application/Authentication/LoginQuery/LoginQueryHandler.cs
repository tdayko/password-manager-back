using MediatR;
using PasswordManager.Application.Persistence;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Authentication.LoginQuery;

public class LoginQueryHandler(IUserRepository userRepository) : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IUserRepository _userRepository = userRepository;
    public Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserbyEmail(request.Email) is not User user)
            throw new Exception("EmailGivenNotFoundException");

        if (user.PasswordHash != request.Password) throw new Exception("InvalidPasswordException");

        return Task.FromResult(new AuthenticationResult(user, "token"));
    }
}