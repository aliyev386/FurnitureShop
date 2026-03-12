using FurnitureShop.Application.Repsitories.Common;
using FurnitureShop.Domain.Entities.Common;
using FurnitureShop.Persistence.Datas;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;

namespace FurnitureShop.Persistence.Repositories.Common;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity, new()
{
    protected readonly AppDbContext _context;
    protected DbSet<T> _table;

    public GenericRepository(AppDbContext appDbContext)
    {
        _context = appDbContext;
        _table = _context.Set<T>();
    }
}