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

public class GenericWriteRepository<T> : GenericRepository<T>, IGenericWriteRepository<T> where T : class
{
    public GenericWriteRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddAsync(T entity)
        => await Table.AddAsync(entity);

    public void Update(T entity)
        => Table.Update(entity);

    public void Delete(T entity)
        => Table.Remove(entity);

    public async Task<int> SaveChangeAsync()
        => await _context.SaveChangesAsync();
}
