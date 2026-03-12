using FurnitureShop.Application.Repsitories.ReadRepositories;
using FurnitureShop.Domain.Entities.Concretes;
using FurnitureShop.Domain.Entities.Enums;
using FurnitureShop.Persistence.Datas;
using FurnitureShop.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Persistence.Repositories.ReadRepositories;

public class OrderReadRepository : GenericReadRepository<Order>, IOrderReadRepository
{
    public OrderReadRepository(AppDbContext dbContext) : base(dbContext) { }

    public async Task<IEnumerable<Order>> GetByUserIdAsync(string userId)
    {
        return await _table
            .Where(x => x.User.Id == userId)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }

    public async Task<Order> GetWithItemsAsync(int id)
    {
        return await _table
            .Include(x => x.Items)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateStatusAsync(int id, OrderStatus status)
    {
        var order = await _table.FindAsync(id);
        if (order != null)
        {
            order.Status = status.ToString();
            await _context.SaveChangesAsync();
        }
    }
}