using FurnitureShop.Domain.Entities.Concretes;
using FurnitureShop.Domain.Entities.Concretes.Translation;
using FurnitureShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Persistence.Datas;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<FurnitureCategory> FurnitureCategories { get; set; }
    public DbSet<CollectionCategory> CollectionCategories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductTranslation> ProductTranslations { get; set; }
    public DbSet<FurnitureCategoryTranslation> FurnitureCategoryTranslations { get; set; }
    public DbSet<CollectionCategoryTranslation> CollectionCategoryTranslations { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<CollectionTranslation> CollectionTranslations { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<HeroSection> HeroSections { get; set; }
    public DbSet<HeroTranslation> HeroTranslations { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<CampaignTranslation> CampaignTranslations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");

        builder.Entity<Product>()
            .Property(p => p.PriceExtra)
            .HasColumnType("decimal(18,2)");

        builder.Entity<Collection>()
            .Property(c => c.TotalPrice)
            .HasColumnType("decimal(18,2)");

        builder.Entity<Collection>()
            .Property(c => c.DiscountPrice)
            .HasColumnType("decimal(18,2)");

        builder.Entity<Order>()
            .Property(o => o.TotalPrice)
            .HasColumnType("decimal(18,2)");

        builder.Entity<OrderItem>()
            .Property(o => o.UnitPrice)
            .HasColumnType("decimal(18,2)");

        builder.Entity<Campaign>()
            .Property(c => c.DiscountPercent)
            .HasColumnType("decimal(5,2)");

        builder.Entity<Collection>()
            .HasMany(c => c.Products)
            .WithMany();

        builder.Entity<Product>()
            .HasOne(p => p.FurnitureCategory)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.FurnitureCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Collection>()
            .HasOne(c => c.CollectionCategory)
            .WithMany(cc => cc.Collections)
            .HasForeignKey(c => c.CollectionCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany()
            .HasForeignKey(oi => oi.ProductId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<OrderItem>()
            .HasOne(oi => oi.Collection)
            .WithMany()
            .HasForeignKey(oi => oi.CollectionId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Entity<ProductTranslation>()
            .HasOne(t => t.Product)
            .WithMany(p => p.Translations)
            .HasForeignKey(t => t.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<FurnitureCategoryTranslation>()
            .HasOne(t => t.FurnitureCategory)
            .WithMany(c => c.Translations)
            .HasForeignKey(t => t.FurnitureCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<CollectionCategoryTranslation>()
            .HasOne(t => t.CollectionCategory)
            .WithMany(c => c.Translations)
            .HasForeignKey(t => t.CollectionCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<CollectionTranslation>()
            .HasOne(t => t.Collection)
            .WithMany(c => c.Translations)
            .HasForeignKey(t => t.CollectionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<HeroTranslation>()
            .HasOne(t => t.HeroSection)
            .WithMany(h => h.Translations)
            .HasForeignKey(t => t.HeroId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<CampaignTranslation>()
            .HasOne(t => t.Campaign)
            .WithMany(c => c.Translations)
            .HasForeignKey(t => t.CampaignId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ProductTranslation>()
            .HasIndex(t => new { t.ProductId, t.Lang })
            .IsUnique();

        builder.Entity<FurnitureCategoryTranslation>()
            .HasIndex(t => new { t.FurnitureCategoryId, t.Lang })
            .IsUnique();

        builder.Entity<CollectionCategoryTranslation>()
            .HasIndex(t => new { t.CollectionCategoryId, t.Lang })
            .IsUnique();

        builder.Entity<CollectionTranslation>()
            .HasIndex(t => new { t.CollectionId, t.Lang })
            .IsUnique();

        builder.Entity<HeroTranslation>()
            .HasIndex(t => new { t.HeroId, t.Lang })
            .IsUnique();

        builder.Entity<CampaignTranslation>()
            .HasIndex(t => new { t.CampaignId, t.Lang })
            .IsUnique();
    }
}
