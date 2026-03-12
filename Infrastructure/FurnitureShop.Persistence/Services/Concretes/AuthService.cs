using FurnitureShop.Application.Services.Abstracts;
using FurnitureShop.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Persistence.Services.Concretes;
public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> RegisterAsync(string email, string username, string password)
    {
        var user = new AppUser
        {
            Email = email,
            UserName = username,
            Username = username
        };

        var result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
        }

        return result;
    }

    public async Task<SignInResult> LoginAsync(string username, string password, bool isPersistent)
    {
        return await _signInManager.PasswordSignInAsync(username, password, isPersistent, lockoutOnFailure: false);
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}