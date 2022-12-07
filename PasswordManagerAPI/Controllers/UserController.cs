using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using PasswordManagerAPI.Data;
using PasswordManagerAPI.Models;
using PasswordManagerAPI.Services;
using PasswordManagerAPI.ViewModels;

namespace PasswordManagerAPI.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    /* register */
    [HttpPost("/api/accounts/register")]
    public async Task<IActionResult> RegisterAsync(
        [FromServices] AppDataContext context,
        [FromBody] UserViewModel model)
    {
        var user = new User
        {
            Name = model.Name,
            Email = model.Email,
            PasswordHash = model.Password
        };

        try
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();

            return Ok("Cadastro concluído com sucesso!");
        }
        catch
        {
            return StatusCode(500, "Ocorreu um erro durante no cadstro da conta!");
        }
    }
    
    /* login */
    [HttpPost("api/accounts/login")]
    public async Task<IActionResult> LoginAsync(
        [FromServices] AppDataContext context,
        [FromServices] TokenService tokenService,
        [FromBody] LoginViewModel model)
    {
        var token = tokenService.GenerateToken(null);
    }
    
}