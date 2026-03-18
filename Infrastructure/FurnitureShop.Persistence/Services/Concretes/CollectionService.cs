using FurnitureShop.Application.Repsitories.Common;
using FurnitureShop.Application.Repsitories.ReadRepositories;
using FurnitureShop.Application.Repsitories.WriteRepositories;
using FurnitureShop.Application.Services.Abstracts;
using FurnitureShop.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Persistence.Services.Concretes;

public class CollectionService : ICollectionService
{
    private readonly ICollectionReadRepository _readRepo;
    private readonly ICollectionWriteRepository _writeRepo;

    public CollectionService(ICollectionReadRepository readRepo, ICollectionWriteRepository writeRepo)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
    }

    public async Task<IEnumerable<Collection>> GetAllAsync() => await _readRepo.GetAllAsync();
    public async Task<Collection> GetByIdAsync(int id) => await _readRepo.GetWithProductsAsync(id);

    public async Task CreateAsync(Collection collection)
    {
        await _writeRepo.AddAsync(collection);
        await _writeRepo.SaveChangeAsync();
    }

    public async Task UpdateAsync(Collection collection)
    {
        _writeRepo.Update(collection);
        await _writeRepo.SaveChangeAsync();
    }

    public async Task DeleteAsync(Collection collection)
    {
        _writeRepo.Delete(collection);
        await _writeRepo.SaveChangeAsync();
    }
    public async Task<List<object>> GetByCategoryIdAsync(int categoryId)
    {
        var collections = await _readRepo.GetWhere(x => x.CollectionCategoryId == categoryId);

        return collections.Select(x => (object)new
        {
            x.Id,
            x.ImagesUrl,
            x.TotalPrice,
            x.DiscountPrice
        }).ToList();
    }
}