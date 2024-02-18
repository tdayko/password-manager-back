using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using NSubstitute;

using PasswordManager.API.Endpoints;
using PasswordManager.Application.Authentication.Contracts;
using PasswordManager.Application.Authentication.LoginQuery;
using PasswordManager.Application.Authentication.RegisterCommand;
using PasswordManager.Application.Contracts;

namespace PasswordManager.UnitTests.Endpoints;

public class AuthenticationEndpointTests
{
    private readonly IEndpointRouteBuilder _routeBuilder = Substitute.For<IEndpointRouteBuilder>();
    private readonly ISender _sender = Substitute.For<ISender>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();

    [Fact]
    public void AddAuthenticationEndpoint_RegistersRoutes()
    {
        // Arrange
        var authEndpoint = _routeBuilder.MapGroup("password-manager/api/");

        // Act
        AuthenticationEndpoint.AddAuthenticationEndpoint(_routeBuilder);

        // Assert
        _routeBuilder.Received().MapGroup("password-manager/api/");
        authEndpoint.Received().MapPost("register", Arg.Any<Delegate>());
        authEndpoint.Received().MapPost("login", Arg.Any<Delegate>());
    }

    [Fact(DisplayName = "Register returns OkResult")]
    public async Task Register_ReturnsOkResult()
    {
        // Arrange
        var request = new RegisterRequest("user", "user@exemple.com", "userpassword");
        var command = new RegisterCommand("user", "user@exemple.com", "userpassword");
        var authResult = new AuthenticationResult(new UserResponse(Guid.Empty, "user@exemple.com", "userpassword"), "token");
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
        var request = new LoginRequest("user@exemple.com", "userpassword");
        var query = new LoginQuery("user@exemple.com", "userpassword");
        var authResult = new AuthenticationResult(new UserResponse(Guid.Empty, "user@exemple.com", "userpassword"), "token");
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