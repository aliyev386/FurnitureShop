using FurnitureShop.Persistence.Datas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Persistence;

public static class RegisterService
{
    public static void AddPersistenceRegister(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        AddRepositoriesExtention(services);
        AddServiceExtention(services);
    }

    private static void AddRepositoriesExtention(IServiceCollection services)
    {


    }

    private static void AddServiceExtention(IServiceCollection services)
    {
        //


    }
}