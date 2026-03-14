using FurnitureShop.Application.Dtos.Auth;
using FurnitureShop.Application.Services.Abstracts;
using FurnitureShop.Domain.Entities.Identity;
using FurnitureShop.Persistence.Datas;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Persistence.Services.Concretes;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly AppDbContext _context;

    public AuthService(UserManager<AppUser> userManager,
                       ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<TokenResponseDto> LoginAsync(LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);

        if (user == null)
            throw new Exception("User not found");

        var result = await _userManager.CheckPasswordAsync(user, dto.Password);

        if (!result)
            throw new Exception("Password incorrect");

        return _tokenService.CreateToken(user);
    }

    public async Task<TokenResponseDto> RegisterAsync(RegisterDto dto)
    {
        var user = new AppUser
        {
            UserName = dto.Email,
            Email = dto.Email,
            Name = dto.Name,
            Surname = dto.Surname,
            RefreshToken = Guid.NewGuid().ToString()
        };


        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"User create failed: {errors}");
        }
        
        return _tokenService.CreateToken(user);
    }

    public async Task<TokenResponseDto> RefreshTokenAsync(TokenResponseDto request)
    {
        var user = await _userManager.Users
            .FirstOrDefaultAsync(x => x.RefreshToken == request.RefreshToken);

        if (user == null)
            throw new Exception("Invalid refresh token");

        if (user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            throw new Exception("Refresh token expired");

        var newAccessToken = _tokenService.CreateAccessToken(user);

        var newRefreshToken = _tokenService.CreateRefreshToken();

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

        await _userManager.UpdateAsync(user);

        return new TokenResponseDto
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
            ExpireDate = DateTime.UtcNow.AddMinutes(15)
        };
    }
}