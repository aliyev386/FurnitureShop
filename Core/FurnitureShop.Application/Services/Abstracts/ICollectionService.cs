using FurnitureShop.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Services.Abstracts;

public interface ICollectionService
{
    Task<IEnumerable<Collection>> GetAllAsync();
    Task<Collection> GetByIdAsync(int id);
    Task CreateAsync(Collection collection);
    Task UpdateAsync(Collection collection);
    Task DeleteAsync(int id);
}