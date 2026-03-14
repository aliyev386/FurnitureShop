using FurnitureShop.Application.Repositories.ReadRepositories;
using FurnitureShop.Application.Repositories.WriteRepositories;
using FurnitureShop.Application.Repsitories.ReadRepositories;
using FurnitureShop.Application.Repsitories.WriteRepositories;
using FurnitureShop.Application.Services.Abstracts;
using FurnitureShop.Domain.Entities.Identity;
using FurnitureShop.Persistence.Datas;
using FurnitureShop.Persistence.Repositories.ReadRepositories;
using FurnitureShop.Persistence.Repositories.WriteRepositories;
using FurnitureShop.Persistence.Services.Concretes;
using Microsoft.AspNetCore.Identity;
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

    private static void AddRepositoriesExtention(IServiceCollection services)
    {
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<ICollectionReadRepository, CollectionReadRepository>();
        services.AddScoped<ICollectionCategoryReadRepository, CollectionCategoryReadRepository>();
        services.AddScoped<IFurnitureCategoryReadRepository, FurnitureCategoryReadRepository>();        
        
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        services.AddScoped<ICollectionWriteRepository, CollectionWriteRepository>();
        services.AddScoped<ICollectionCategoryWriteRepository, CollectionCategoryWriteRepository>();
        services.AddScoped<IFurnitureCategoryWriteRepository, FurnitureCategoryWriteRepository>();        
        

    }

    private static void AddServiceExtention(IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ICollectionService, CollectionService>();
        services.AddScoped<ICollectionCategoryService, CollectionCategoryService>();
        services.AddScoped<IFurnitureCategoryService, FurnitureCategoryService>();
        services.AddScoped<IAuthService, AuthService>();
    }
}