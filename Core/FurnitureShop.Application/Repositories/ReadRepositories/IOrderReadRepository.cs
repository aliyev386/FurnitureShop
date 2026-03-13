using FurnitureShop.Application.Repsitories.Common;
using FurnitureShop.Domain.Entities.Concretes;
using FurnitureShop.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Repsitories.ReadRepositories;

public interface IOrderReadRepository:IGenericReadRepository<Order>
{
    Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId);//userein orderlerini getirir
    Task<Order> GetWithItemsAsync(int id);//orderin icindekiler
    Task UpdateStatusAsync(int id, OrderStatus status);//basa dusmedim

}
