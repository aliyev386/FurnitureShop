using FurnitureShop.Application.Repsitories.ReadRepositories;
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

public class ProductReadRepository : GenericReadRepository<Product>, IProductReadRepository
{
    public ProductReadRepository(AppDbContext dbContext) : base(dbContext) { }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
    {
        return await _table.Where(x => x.FurnitureCategoryId == categoryId).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetFeaturedAsync()
    {
        return await _table.Where(x => x.IsFeatured)
                           .OrderBy(x => x.DisplayOrder)
                           .ToListAsync();
    }

    public async Task<IEnumerable<Product>> SearchAsync(string keyword, string language)
    {
        return await _table
            .Include(x => x.Translations)
            .Where(p => p.Translations.Any(t =>
                t.LanguageCode == language &&
                (t.Name.Contains(keyword) || t.Description.Contains(keyword))
            ))
            .ToListAsync();
    }
}