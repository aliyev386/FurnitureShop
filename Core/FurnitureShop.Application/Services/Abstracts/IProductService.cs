using FurnitureShop.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Services.Abstracts;

public interface IProductService
{
    Task<IEnumerable<Product>> SearchAsync(string keyword, string lang);
    Task<Product> GetByIdAsync(int id);
    Task CreateAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}