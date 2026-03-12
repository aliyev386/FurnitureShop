using FurnitureShop.Application.Repsitories.Common;
using FurnitureShop.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Repositories.ReadRepositories
{
    public interface IAuthReadRepository : IGenericReadRepository<AppUser>
    {
        Task<AppUser> GetByEmailAsync(string email);
    }
}
