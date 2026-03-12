using FurnitureShop.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Repsitories.Common;

public interface IGenericReadRepository<T> : IGenericRepository<T> where T : class, IBaseEntity, new()
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IQueryable<T>> GetExpressionAsync(Expression<Func<T, bool>> expression);
    Task<T> GetByIdAsync(int id);
}
