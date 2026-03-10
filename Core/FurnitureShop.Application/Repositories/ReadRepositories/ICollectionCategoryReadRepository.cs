using FurnitureShop.Application.Repsitories.Common;
using FurnitureShop.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Repsitories.ReadRepositories;

public interface ICategoryReadRepository:IGenericReadRepository<Category>
{
    Task<IEnumerable<FurnitureCategory>> GetFurnitureCategoriesAsync();
    Task<IEnumerable<CollectionCategory>> GetRoomCategoriesAsync();

}

