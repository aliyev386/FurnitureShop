using FurnitureShop.Application.Repsitories.Common;
using FurnitureShop.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Repsitories.ReadRepositories;

public interface ICollectionReadRepository:IGenericReadRepository<Collection>
{
    Task<IEnumerable<Collection>> GetByRoomCategoryAsync(int roomCategoryId);//bu categoriyaya uygun destleri getirir
    Task<Collection> GetWithProductsAsync(int id); //destleri productlari ile biryerde getirir

}
