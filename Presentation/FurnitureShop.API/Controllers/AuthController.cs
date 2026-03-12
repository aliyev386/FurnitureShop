using FurnitureShop.Application.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureShop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService) => _authService = authService;

    [HttpPost("register")]
    public async Task<IActionResult> Register(string email, string username, string password)
    {
        var result = await _authService.RegisterAsync(email, username, password);
        return result.Succeeded ? Ok("İstifadəçi yaradıldı") : BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string username, string password)
    {
        var result = await _authService.LoginAsync(username, password, false);
        return result.Succeeded ? Ok("Giriş uğurludur") : Unauthorized();
    }
}