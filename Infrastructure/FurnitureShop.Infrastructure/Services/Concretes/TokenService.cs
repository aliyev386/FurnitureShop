using FurnitureShop.Application.Dtos.Auth;
using FurnitureShop.Application.Services.Abstracts;
using FurnitureShop.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Infrastructure.Services.Concretes;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TokenResponseDto CreateToken(AppUser user)
    {
        var accessToken = CreateAccessToken(user);

        return new TokenResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = CreateRefreshToken(),
            ExpireDate = DateTime.UtcNow.AddMinutes(15)
        };
    }

    public string CreateRefreshToken()
    {
        var random = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(random);
        return Convert.ToBase64String(random);
    }
    public string CreateAccessToken(AppUser user)
    {
        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.Email)
    };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])
        );

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:Issuer"],
            audience: _configuration["JWT:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(15),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}