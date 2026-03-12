using FurnitureShop.Application.Repsitories.Common;
using FurnitureShop.Domain.Entities.Common;
using FurnitureShop.Persistence.Datas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Persistence.Repositories.Common;

public class GenericReadRepository<T> : GenericRepository<T>, IGenericReadRepository<T> where T : class, IBaseEntity, new()
{
    public GenericReadRepository(AppDbContext dbContext) : base(dbContext)
    {

    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return _table;
    }

    public Task<T> GetByIdAsync(int id)
    {
        return _table.FirstOrDefaultAsync(x => x.Id == id)!;
    }

    public async Task<IQueryable<T>> GetExpressionAsync(Expression<Func<T, bool>> expression)
    {
        return _table.Where(expression);
    }
}