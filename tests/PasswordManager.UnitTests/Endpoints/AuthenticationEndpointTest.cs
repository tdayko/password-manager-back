using AutoMapper;
using NSubstitute;
using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

using PasswordManager.API.Endpoints;
using PasswordManager.Application.Authentication.Contracts;
using PasswordManager.Application.Authentication.LoginQuery;
using PasswordManager.Application.Authentication.RegisterCommand;
using PasswordManager.Application.Contracts;
using PasswordManager.Domain.Entities;


namespace PasswordManager.UnitTests.Endpoints;

public class AuthenticationEndpointTests
{
    private readonly ISender _sender = Substitute.For<ISender>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();
    private readonly User _user = new("user", "user@exemple.com", "userpassword");

    [Fact(DisplayName = "Register returns OkResult")]
    public async Task Register_ReturnsOkResult()
    {
        // Arrange
        var request = new RegisterRequest(_user.Username, _user.Email, _user.Password);
        var command = new RegisterCommand(_user.Username, _user.Email, _user.Password);
        var authResult = new AuthenticationResult(new UserResponse(_user.Id, _user.Email, _user.Password), "token");
        var response = new StandardSuccessResponse<AuthenticationResult>(authResult);

        _mapper.Map<RegisterCommand>(request).Returns(command);
        _sender.Send(command).Returns(Task.FromResult(authResult));
        _mapper.Map<StandardSuccessResponse<AuthenticationResult>>(authResult).Returns(response);

        // Act
        var okResult = (Ok<StandardSuccessResponse<AuthenticationResult>>) await AuthenticationEndpoint.HandleRegister(request, _sender, _mapper);

        // Assert
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        Assert.Equal(response, okResult.Value);
    }

    [Fact(DisplayName = "Login returns OkResult")]
    public async Task Login_ReturnsOkResult()
    {
        // Arrange
        var request = new LoginRequest(_user.Email, _user.Password);
        var query = new LoginQuery(_user.Email, _user.Password);
        var authResult = new AuthenticationResult(new UserResponse(_user.Id, _user.Email, _user.Password), "token");
        var response = new StandardSuccessResponse<AuthenticationResult>(authResult);

        _mapper.Map<LoginQuery>(request).Returns(query);
        _sender.Send(query).Returns(Task.FromResult(authResult));
        _mapper.Map<StandardSuccessResponse<AuthenticationResult>>(authResult).Returns(response);

        // Act
        var okResult = (Ok<StandardSuccessResponse<AuthenticationResult>>) await AuthenticationEndpoint.HandleLogin(request, _sender, _mapper);

        // Assert
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        Assert.Equal(response, okResult.Value);
    }
}