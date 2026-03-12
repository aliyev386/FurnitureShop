using FurnitureShop.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Services.Abstracts;
public interface ICollectionCategoryService
{
    Task<IEnumerable<CollectionCategory>> GetAllWithTranslationsAsync(string langCode);
    Task<CollectionCategory> GetByIdAsync(int id, string langCode);
    Task CreateAsync(CollectionCategory category);
    Task DeleteAsync(int id);
}