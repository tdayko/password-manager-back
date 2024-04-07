// using AutoMapper;
// using NSubstitute;
// using MediatR;

// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Http.HttpResults;

// using PasswordManager.API.Endpoints;
// using PasswordManager.Application.Persistence.Authentication.Contracts;
// using PasswordManager.Application.Persistence.Authentication.LoginQuery;
// using PasswordManager.Application.Persistence.Authentication.RegisterCommand;
// using PasswordManager.Application.Contracts;
// using PasswordManager.Domain.Entities;

// namespace PasswordManager.UnitTests.Endpoints;

// public class AuthenticationEndpointTests
// {
//     private readonly IMapper _mapper = Substitute.For<IMapper>();
//     private readonly ISender _sender = Substitute.For<ISender>();
//     private readonly User _user = new("user", "user@exemple.com", "userpassword");

//     [Fact(DisplayName = "Register returns OkResult")]
//     public async Task Register_ReturnsOkResult()
//     {
//         // Arrange
//         RegisterRequest request = new(_user.Username, _user.Email, _user.Password);
//         RegisterCommand command = new(_user.Username, _user.Email, _user.Password);

//         AuthenticationResult authResult = new(new UserResponse(_user.Id, _user.Email, _user.Password), "token");
//         StandardSuccessResponse<AuthenticationResult> response = new(authResult);

//         _mapper.Map<RegisterCommand>(request).Returns(command);
//         _sender.Send(command).Returns(Task.FromResult(authResult));
//         _mapper.Map<StandardSuccessResponse<AuthenticationResult>>(authResult).Returns(response);

//         // Act
//         Ok<StandardSuccessResponse<AuthenticationResult>> okResult =
//             (Ok<StandardSuccessResponse<AuthenticationResult>>)
//                 await AuthenticationEndpoint.HandleRegister(request, _sender, _mapper);

//         // Assert
//         Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
//         Assert.Equal(response, okResult.Value);
//     }

//     [Fact(DisplayName = "Login returns OkResult")]
//     public async Task Login_ReturnsOkResult()
//     {
//         // Arrange
//         LoginRequest request = new(_user.Email, _user.Password);
//         LoginQuery query = new(_user.Email, _user.Password);

//         AuthenticationResult authResult = new(new UserResponse(_user.Id, _user.Email, _user.Password), "token");
//         StandardSuccessResponse<AuthenticationResult> response = new(authResult);

//         _mapper.Map<LoginQuery>(request).Returns(query);
//         _sender.Send(query).Returns(Task.FromResult(authResult));
//         _mapper.Map<StandardSuccessResponse<AuthenticationResult>>(authResult).Returns(response);

//         // Act
//         Ok<StandardSuccessResponse<AuthenticationResult>> okResult =
//             (Ok<StandardSuccessResponse<AuthenticationResult>>)
//                 await AuthenticationEndpoint.HandleLogin(request, _sender, _mapper);

//         // Assert
//         Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
//         Assert.Equal(response, okResult.Value);
//     }
// }

