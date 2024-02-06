using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using PasswordManager.Application.Authentication;
using PasswordManager.Application.Authentication.LoginQuery;
using PasswordManager.Application.Authentication.RegisterCommand;
using PasswordManager.Application.Contracts.Authentication;

namespace PasswordManager.API.Controller;

[ApiController]
[Route("password-manager/api")]
public class AuthenticationController(ISender sender, IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly ISender _sender = sender;

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        AuthenticationResult authResult = await _sender.Send(_mapper.Map<RegisterCommand>(request));
        return Ok(authResult);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        AuthenticationResult authResult = await _sender.Send(_mapper.Map<LoginQuery>(request));
        return Ok(authResult);
    }
}