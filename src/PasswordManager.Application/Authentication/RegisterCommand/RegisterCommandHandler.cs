using AutoMapper;

using MediatR;

using PasswordManager.Application.Authentication.Contracts;
using PasswordManager.Application.Contracts;
using PasswordManager.Application.Errors;
using PasswordManager.Application.Persistence;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Authentication.RegisterCommand;

public class RegisterCommandHandler(
    IUserRepository userRepository,
    IJwtTokenGenerator jwtTokenGenerator,
    IMapper mapper)
    : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
    private readonly IMapper _mapper = mapper;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserbyEmail(request.Email) is not null)
        {
            throw new DuplicateEmailException();
        }

        User user = new(request.Username, request.Password, request.Email);
        _userRepository.AddUser(user);

        string token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(_mapper.Map<UserResponse>(user), token);
    }
}