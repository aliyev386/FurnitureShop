using FurnitureShop.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Services.Abstracts;

public interface IFurnitureCategoryService
{
    Task<IEnumerable<FurnitureCategory>> GetAllAsync();
    Task CreateAsync(FurnitureCategory category);
    Task UpdateAsync(FurnitureCategory category);
    Task DeleteAsync(int id);
}