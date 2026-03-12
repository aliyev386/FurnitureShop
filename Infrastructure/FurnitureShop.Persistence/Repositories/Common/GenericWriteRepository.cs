using FurnitureShop.Application.Repsitories.Common;
using FurnitureShop.Domain.Entities.Common;
using FurnitureShop.Persistence.Datas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Persistence.Repositories.Common;

public class GenericWriteRepository<T> : GenericRepository<T>, IGenericWriteRepository<T> where T : class, IBaseEntity, new()
{
    public GenericWriteRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddAsync(T entity)
    {
        await _table.AddAsync(entity);
    }

    public async Task AddRangeAsync(List<T> entities)
    {
        await _table.AddRangeAsync(entities);
    }

    public void Delete(T entity)
    {
        _table.Remove(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await _table.FirstOrDefaultAsync(x => x.Id == id);

        _table.Remove(entity!);
    }

    public void DeleteRange(List<T> entities)
    {
        _table.RemoveRange(entities);
    }

    public async Task SaveChangeAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _table.Update(entity);
    }
}
