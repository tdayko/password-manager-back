using AutoMapper;
using MediatR;

using PasswordManager.Application.Contracts;
using PasswordManager.Application.Errors;
using PasswordManager.Application.Persistence.Authentication.Contracts;
using PasswordManager.Application.Repositories;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.Persistence.Authentication.RegisterCommand;

public class RegisterCommandHandler(
    IUserRepository userRepository,
    IJwtTokenGenerator jwtTokenGenerator,
    IMapper mapper
) : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
    private readonly IMapper _mapper = mapper;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_userRepository.GetUserByEmail(request.Email) is not null)
        {
            throw new DuplicateEmailException();
        }
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        User user = new(request.Username, passwordHash, request.Email);
        _userRepository.AddUser(user);

        string token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(_mapper.Map<UserResponse>(user), token);
    }
}