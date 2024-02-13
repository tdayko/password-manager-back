using AutoMapper;

using MediatR;

using PasswordManager.Application.Authentication.Contracts;
using PasswordManager.Application.Errors;
using PasswordManager.Application.Persistence;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Authentication.LoginQuery;

public class LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator, IMapper mapper) : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
    private readonly IMapper _mapper = mapper;

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

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(_mapper.Map<UserResponse>(user), token);
    }
}