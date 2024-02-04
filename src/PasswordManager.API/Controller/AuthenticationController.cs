using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Application.Authentication.LoginQuery;
using PasswordManager.Application.Authentication.RegisterCommand;
using PasswordManager.Application.Contracts;

namespace PasswordManager.API.Controller;

[ApiController]
[Route("password-manager/api")]
public class AuthenticationController(ISender sender, IMapper mapper) : ControllerBase
{
    private readonly ISender _sender = sender;
    private readonly IMapper _mapper = mapper;
  
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        _ = await _sender.Send(_mapper.Map<RegisterCommand>(request));
        return Ok(new AuthenticationResponse(Guid.NewGuid(), request.Username, request.Email, "token"));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        _ = await _sender.Send(_mapper.Map<LoginQuery>(request));
        return Ok(new AuthenticationResponse(Guid.NewGuid(), request.Email, request.Password, "token"));
    }
}