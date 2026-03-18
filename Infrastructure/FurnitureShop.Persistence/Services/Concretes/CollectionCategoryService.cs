using FurnitureShop.Application.Dtos.Collection;
using FurnitureShop.Application.Dtos.CollectionCategory;
using FurnitureShop.Application.Repsitories.Common;
using FurnitureShop.Application.Repsitories.ReadRepositories;
using FurnitureShop.Application.Repsitories.WriteRepositories;
using FurnitureShop.Application.Services.Abstracts;
using FurnitureShop.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Persistence.Services.Concretes;
public class CollectionCategoryService : ICollectionCategoryService
{
    private readonly ICollectionCategoryReadRepository _readRepo;
    private readonly ICollectionCategoryWriteRepository _writeRepo;

    public CollectionCategoryService(
        ICollectionCategoryReadRepository readRepo, ICollectionCategoryWriteRepository writeRepo)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
    }

    public async Task<IEnumerable<CollectionCategoryDto>> GetAllWithTranslationsAsync(string langCode)
    {
        var categories = await _readRepo.GetRoomCategoriesAsync();

        return categories.Select(x => new CollectionCategoryDto
        {
            Id = x.Id,
            Name = x.Translations
                .FirstOrDefault(t => t.Lang == langCode)?.Name
        });
    }

    public async Task<CollectionCategory> GetByIdAsync(int id, string langCode)
    {
        return await _readRepo.GetByIdAsync(id);
    }

    public async Task CreateAsync(CollectionCategory category)
    {
        await _writeRepo.AddAsync(category);
        await _writeRepo.SaveChangeAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _readRepo.GetByIdAsync(id);
        if (entity != null)
        {
            _writeRepo.Delete(entity);
            await _writeRepo.SaveChangeAsync();
        }
    }

    public async Task<List<object>> GetAllSimpleAsync(string lang)
    {
        var categories = await _readRepo.GetAllAsync();

        return categories.Select(x => (object)new
        {
            x.Id,
            Name = x.Translations
                .FirstOrDefault(t => t.Lang == lang)?.Name
        }).ToList();
    }

    public async Task<List<CollectionDto>> GetByCategoryIdAsync(int categoryId)
    {
        var collections = await _readRepo.GetAllAsync();

        return collections
            .Where(x => x.CollectionCategoryId == categoryId)
            .Select(x => new CollectionDto
            {
                Id = x.Id,
                ImageUrl = x.ImagesUrl,
                TotalPrice = x.TotalPrice
            })
            .ToList();
    }
}