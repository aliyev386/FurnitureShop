using FurnitureShop.Application.Repsitories.Common;
using FurnitureShop.Domain.Entities.Common;
using FurnitureShop.Persistence.Datas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FurnitureShop.Persistence.Repositories.Common;
public class GenericReadRepository<T> : GenericRepository<T>, IGenericReadRepository<T> where T : class
{
    public GenericReadRepository(AppDbContext context) : base(context) { }

    public IQueryable<T> GetAll()
        => Table.AsNoTracking();

    public async Task<IEnumerable<T>> GetAllAsync()
        => await Table.AsNoTracking().ToListAsync();

    public async Task<T> GetByIdAsync(int id)
        => await Table.FindAsync(id);

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        => await Table.AsNoTracking().FirstOrDefaultAsync(predicate);

    public IQueryable<T> AsQueryable() => Table.AsNoTracking();

}
