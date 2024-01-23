using MediatR;
using Microsoft.AspNetCore.Mvc;

using PasswordManager.Application.Authentication.RegisterCommand;
using PasswordManager.Application.Contracts;

namespace PasswordManager.API.Controller;

[ApiController]
[Route("password-manager/api/auth")]
public class AuthenticationController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPut]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.Username, request.Email, request.Password);
        var authResult = await _sender.Send(command);

        return Ok(new AuthenticationResponse(Guid.NewGuid(), request.Username, request.Email, "token"));
    }
}