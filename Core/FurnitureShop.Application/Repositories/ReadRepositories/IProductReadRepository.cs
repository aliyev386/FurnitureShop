using FurnitureShop.Application.Repsitories.Common;
using FurnitureShop.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Repsitories.ReadRepositories;

public interface IProductReadRepository:IGenericReadRepository<Product>
{
    Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId); //categorye uygun productlar getirir
    Task<IEnumerable<Product>> GetFeaturedAsync();//onerilen productlari getirir
    Task<IEnumerable<Product>> SearchAsync(string keyword, string language);//basa dusmedim
 //   Task<PaginatedResult<Product>> GetPaginatedAsync(int page, int pageSize, int? categoryId);

}
