using FurnitureShop.Application.Services.Abstracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Application
{
    public static class RegisterService
    {
        public static void AddApplicationRegister(this IServiceCollection services)
        {           
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(RegisterService).Assembly));
        }
    }
}
