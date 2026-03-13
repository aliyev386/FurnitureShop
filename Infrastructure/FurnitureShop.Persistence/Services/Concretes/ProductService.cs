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
public class ProductService : IProductService
{
    private readonly IProductReadRepository _readRepo;
    private readonly IProductWriteRepository _writeRepo;

    public ProductService(IProductReadRepository readRepo, IProductWriteRepository writeRepo)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
    }

    public async Task<IEnumerable<Product>> SearchAsync(string keyword, string lang) => await _readRepo.SearchAsync(keyword, lang);
    public async Task<Product> GetByIdAsync(int id) => await _readRepo.GetByIdAsync(id);

    public async Task CreateAsync(Product product)
    {
        await _writeRepo.AddAsync(product);
        await _writeRepo.SaveChangeAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _writeRepo.Update(product);
        await _writeRepo.SaveChangeAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _readRepo.GetByIdAsync(id);
        if (product != null)
        {
            _writeRepo.Delete(product);
            await _writeRepo.SaveChangeAsync();
        }
    }
}