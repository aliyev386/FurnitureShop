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

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }
    public DbSet<T> Table => _context.Set<T>();
}
