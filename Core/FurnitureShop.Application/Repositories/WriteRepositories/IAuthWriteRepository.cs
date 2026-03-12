using FurnitureShop.Application.Repsitories.Common;
using FurnitureShop.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Repositories.WriteRepositories
{
    public interface IAuthWriteRepository : IGenericWriteRepository<AppUser>
    {
    }
}
