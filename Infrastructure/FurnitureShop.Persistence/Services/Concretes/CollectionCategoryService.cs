using FurnitureShop.Application.Repsitories.Common;
using FurnitureShop.Application.Repsitories.ReadRepositories;
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
    private readonly IGenericWriteRepository<CollectionCategory> _writeRepo;

    public CollectionCategoryService(
        ICollectionCategoryReadRepository readRepo,
        IGenericWriteRepository<CollectionCategory> writeRepo)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
    }

    public async Task<IEnumerable<CollectionCategory>> GetAllWithTranslationsAsync(string langCode)
    {
        var categories = await _readRepo.GetRoomCategoriesAsync();

        return categories;
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
        await _writeRepo.Delete(id);
        await _writeRepo.SaveChangeAsync();
    }
}