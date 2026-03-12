using FurnitureShop.Application.Repsitories.Common;
using FurnitureShop.Application.Repsitories.ReadRepositories;
using FurnitureShop.Application.Services.Abstracts;
using FurnitureShop.Domain.Entities.Concretes;
using FurnitureShop.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Persistence.Services.Concretes;

public class OrderService : IOrderService
{
    private readonly IOrderReadRepository _readRepo;
    private readonly IGenericWriteRepository<Order> _writeRepo;

    public OrderService(IOrderReadRepository readRepo, IGenericWriteRepository<Order> writeRepo)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
    }

    public async Task<IEnumerable<Order>> GetUserOrdersAsync(string userId) => await _readRepo.GetByUserIdAsync(userId);
    public async Task<Order> GetOrderDetailsAsync(int id) => await _readRepo.GetWithItemsAsync(id);

    public async Task CreateOrderAsync(Order order)
    {
        order.CreatedAt = DateTime.UtcNow;
        order.Status = OrderStatus.Pending.ToString();
        await _writeRepo.AddAsync(order);
        await _writeRepo.SaveChangeAsync();
    }

    public async Task CancelOrderAsync(int id)
    {
        var order = await _readRepo.GetByIdAsync(id);
        if (order != null)
        {
            order.Status = OrderStatus.Cancelled.ToString();
            _writeRepo.Update(order);
            await _writeRepo.SaveChangeAsync();
        }
    }
}