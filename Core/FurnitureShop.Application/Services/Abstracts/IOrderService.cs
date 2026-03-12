using FurnitureShop.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Services.Abstracts;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetUserOrdersAsync(string userId);
    Task<Order> GetOrderDetailsAsync(int id);
    Task CreateOrderAsync(Order order);
    Task CancelOrderAsync(int id);
}