using FurnitureShop.Application.Services.Abstracts;
using FurnitureShop.Persistence.Datas;
using FurnitureShop.Persistence.Services.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ICollectionService, CollectionService>();
        services.AddScoped<ICollectionCategoryService, CollectionCategoryService>();
        services.AddScoped<IFurnitureCategoryService, FurnitureCategoryService>();
        services.AddScoped<IAuthService, AuthService>();
    }
    private static void AddRepositoriesExtention(IServiceCollection services)
    {


    }

    private static void AddServiceExtention(IServiceCollection services)
    {
        //


    }
}