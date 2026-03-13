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
    public TokenResponseDto CreateToken(AppUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supersecretkey123456"));

        var token = new JwtSecurityToken(
            issuer: "FurnitureAPI",
            audience: "FurnitureAPI",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(15),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        var handler = new JwtSecurityTokenHandler();

        return new TokenResponseDto
        {
            AccessToken = handler.WriteToken(token),
            RefreshToken = CreateRefreshToken(),
            ExpireDate = token.ValidTo
        };
    }

    public string CreateRefreshToken()
    {
        var random = new byte[32];

        using var rng = RandomNumberGenerator.Create();

        rng.GetBytes(random);

        return Convert.ToBase64String(random);
    }
}