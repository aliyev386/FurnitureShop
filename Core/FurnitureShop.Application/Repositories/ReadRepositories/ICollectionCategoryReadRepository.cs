using FurnitureShop.Application.Repsitories.Common;
using FurnitureShop.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Repsitories.ReadRepositories;

public interface ICollectionCategoryReadRepository:IGenericReadRepository<CollectionCategory>
{    
    Task<IEnumerable<CollectionCategory>> GetRoomCategoriesAsync(); // bu method ise sadece collection categoryleri getirir

}

