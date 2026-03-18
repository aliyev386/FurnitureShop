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

namespace FurnitureShop.Persistence.Repositories.ReadRepositories
{
    public class CollectionCategoryReadRepository : GenericReadRepository<CollectionCategory>, ICollectionCategoryReadRepository
    {
        public CollectionCategoryReadRepository(AppDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<CollectionCategory>> GetRoomCategoriesAsync()
        {
            return await Table
                .Select(x => new CollectionCategory
                {
                    Id = x.Id,
                    Translations = x.Translations
                })
                .ToListAsync();
        }
    }
}
