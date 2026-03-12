using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Services.Abstracts;

public interface IAuthService
{
    Task<IdentityResult> RegisterAsync(string email, string username, string password);
    Task<SignInResult> LoginAsync(string username, string password, bool isPersistent);
    Task LogoutAsync();
}