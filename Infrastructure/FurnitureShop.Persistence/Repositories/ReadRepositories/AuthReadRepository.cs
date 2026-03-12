using FurnitureShop.Application.Repositories.ReadRepositories;
using FurnitureShop.Domain.Entities.Concretes;
using FurnitureShop.Persistence.Datas;
using FurnitureShop.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Persistence.Repositories.ReadRepositories
{
    public class AuthReadRepository : GenericReadRepository<AppUser>, IAuthReadRepository
    {
        public AuthReadRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<AppUser> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
