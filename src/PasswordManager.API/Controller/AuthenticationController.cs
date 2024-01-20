using MediatR;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Application.Contracts;

namespace PasswordManager.API.Controller;

[ApiController]
[Route("password-manager/api/auth")]
public class AuthenticationController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;
}