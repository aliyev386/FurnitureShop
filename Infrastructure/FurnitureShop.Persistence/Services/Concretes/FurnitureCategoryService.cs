using FurnitureShop.Application.Repositories.ReadRepositories;
using FurnitureShop.Application.Repsitories.Common;
using FurnitureShop.Application.Services.Abstracts;
using FurnitureShop.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Persistence.Services.Concretes;

public class FurnitureCategoryService : IFurnitureCategoryService
{
    private readonly IFurnitureCategoryReadRepository _readRepo;
    private readonly IGenericWriteRepository<FurnitureCategory> _writeRepo;

    public FurnitureCategoryService(IFurnitureCategoryReadRepository readRepo, IGenericWriteRepository<FurnitureCategory> writeRepo)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
    }

    public async Task<IEnumerable<FurnitureCategory>> GetAllAsync() => await _readRepo.GetFurnitureCategoriesAsync();

    public async Task CreateAsync(FurnitureCategory category)
    {
        await _writeRepo.AddAsync(category);
        await _writeRepo.SaveChangeAsync();
    }

    public async Task UpdateAsync(FurnitureCategory category)
    {
        _writeRepo.Update(category);
        await _writeRepo.SaveChangeAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await _writeRepo.Delete(id);
        await _writeRepo.SaveChangeAsync();
    }
}