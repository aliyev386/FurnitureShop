using FurnitureShop.Application.Dtos.Auth;
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
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var result = await _authService.RegisterAsync(registerDto.Email, registerDto.Name, registerDto.Password);

        return result.Succeeded ? Ok("İstifadəçi yaradıldı") : BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var result = await _authService.LoginAsync(loginDto.Email, loginDto.Password, false);

        return result.Succeeded ? Ok("Giriş uğurludur") : Unauthorized();
    }
}