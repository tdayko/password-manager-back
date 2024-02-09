using MediatR;

using PasswordManager.Application.Authentication.Contracts;
using PasswordManager.Application.Errors;
using PasswordManager.Application.Persistence;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Authentication.RegisterCommand;

public class RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

    public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserbyEmail(request.Email) is not null)
        {
            throw new DuplicateEmailException();
        }

        User user = new(request.Username, request.Password, request.Email);
        _userRepository.AddUser(user);

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}