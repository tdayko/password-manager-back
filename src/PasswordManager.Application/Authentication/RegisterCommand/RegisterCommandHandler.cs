using MediatR;
using PasswordManager.Application.Persistence;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Authentication.RegisterCommand;

public class RegisterCommandHandler(IUserRepository userRepository) : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserbyEmail(request.Email) is not null)
            throw new Exception("DuplicateEmailException");

        var user = new User(request.Username, request.Password, request.Email);
        _userRepository.AddUser(user);

        return new AuthenticationResult(user, "token");
    }
}