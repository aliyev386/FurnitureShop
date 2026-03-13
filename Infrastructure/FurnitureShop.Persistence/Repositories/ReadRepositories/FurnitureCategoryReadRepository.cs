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

namespace FurnitureShop.Persistence.Repositories.ReadRepositories;

public class FurnitureCategoryReadRepository : GenericReadRepository<FurnitureCategory>, IFurnitureCategoryReadRepository
{
    public FurnitureCategoryReadRepository(AppDbContext dbContext) : base(dbContext) { }

    public async Task<IEnumerable<FurnitureCategory>> GetFurnitureCategoriesAsync()
    {
        return await Table
            .Include(x => x.Translations)
            .ToListAsync();
    }
}