using FurnitureShop.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application.Repsitories.Common
{
    public interface IGenericWriteRepository<T> : IGenericRepository<T> where T : class, IBaseEntity, new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        void Update(T entity);
        void Delete(T entity);
        Task Delete(int id);
        void DeleteRange(List<T> entities);
        Task SaveChangeAsync();
    }
}
