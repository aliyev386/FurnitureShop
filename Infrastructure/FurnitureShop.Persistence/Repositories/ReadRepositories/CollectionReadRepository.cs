using FurnitureShop.Application.Repsitories.ReadRepositories;
using FurnitureShop.Domain.Entities.Concretes;
using FurnitureShop.Persistence.Datas;
using FurnitureShop.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Persistence.Repositories.ReadRepositories;

public class CollectionReadRepository : GenericReadRepository<Collection>, ICollectionReadRepository
{
    public CollectionReadRepository(AppDbContext dbContext) : base(dbContext) { }

    public async Task<IEnumerable<Collection>> GetByRoomCategoryAsync(int roomCategoryId)
    {
        return await Table
            .Where(x => x.CollectionCategoryId == roomCategoryId)
            .Include(x => x.Translations)
            .ToListAsync();
    }

    public async Task<Collection> GetWithProductsAsync(int id)
    {
        return await Table
            .Include(x => x.Products)
            .Include(x => x.Translations)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}