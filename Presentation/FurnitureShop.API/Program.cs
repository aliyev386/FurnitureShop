using FluentValidation;
using FluentValidation.AspNetCore;
using FurnitureShop.Application.Services.Abstracts;
using FurnitureShop.Application.Validation.FluentValidation.Concrete;
using FurnitureShop.Domain.Entities.Identity;
using FurnitureShop.Infrastructure;
using FurnitureShop.Persistence;
using FurnitureShop.Persistence.Datas;
using FurnitureShop.Persistence.Services.Concretes;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceRegister(builder.Configuration);
builder.Services.AddInfrastructureRegister(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();

builder.Services
.AddIdentity<AppUser, AppRole>()
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new AppRole
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Admin",
            NormalizedName = "ADMIN"
        });
    }
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();